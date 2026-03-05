using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Security.Principal;

public sealed class WrappedImpersonationContext
{
    public enum LogonProvider
    {
        Default = 0, // LOGON32_PROVIDER_DEFAULT
        WinNT35 = 1,
        WinNT40 = 2, // Use the NTLM logon provider.
        WinNT50 = 3 // Use the negotiate logon provider.
    }

    public enum LogonType
    {
        Interactive = 2,
        Network = 3,
        Batch = 4,
        Service = 5,
        Unlock = 7,
        NetworkClearText = 8,
        NewCredentials = 9
    }

    private WindowsImpersonationContext _context;

    private readonly string _domain;
    private readonly string _password;
    private readonly string _username;
    private IntPtr _token;

    public WrappedImpersonationContext(string domain, string username, string password)
    {
        _domain = string.IsNullOrEmpty(domain) ? "." : domain;
        _username = username;
        _password = password;
    }

    private bool IsInContext => _context != null;

    [DllImport("advapi32.dll", EntryPoint = "LogonUserW", SetLastError = true, CharSet = CharSet.Unicode)]
    public static extern bool LogonUser(string lpszUsername, string lpszDomain,
        string lpszPassword, LogonType dwLogonType, LogonProvider dwLogonProvider, ref IntPtr phToken);

    [DllImport("kernel32.dll")]
    public static extern bool CloseHandle(IntPtr handle);

    // Changes the Windows identity of this thread. Make sure to always call Leave() at the end.
    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    public void Enter()
    {
        if (IsInContext)
            return;

        _token = IntPtr.Zero;
        var logonSuccessfull = LogonUser(_username, _domain, _password, LogonType.NewCredentials, LogonProvider.WinNT50,
            ref _token);
        if (!logonSuccessfull) throw new Win32Exception(Marshal.GetLastWin32Error());
        var identity = new WindowsIdentity(_token);
        _context = identity.Impersonate();

        Debug.WriteLine(WindowsIdentity.GetCurrent().Name);
    }

    [PermissionSetAttribute(SecurityAction.Demand, Name = "FullTrust")]
    public void Leave()
    {
        if (!IsInContext)
            return;

        _context.Undo();

        if (_token != IntPtr.Zero) CloseHandle(_token);
        _context = null;
    }
}
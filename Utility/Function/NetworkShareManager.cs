using System;
using System.ComponentModel;
using System.Net;
using System.Runtime.InteropServices;

public static class NetworkShare
{
    /// <summary>
    ///     Connects to the remote share
    /// </summary>
    /// <returns>Null if successful, otherwise error message.</returns>
    public static string ConnectToShare(string uri, string username, string password)
    {
        //Create netresource and point it at the share
        var nr = new NETRESOURCE();
        nr.dwType = RESOURCETYPE_DISK;
        nr.lpRemoteName = uri;

        //Create the share
        var ret = WNetUseConnection(IntPtr.Zero, nr, password, username, 0, null, null, null);

        //Check for errors
        if (ret == NO_ERROR)
            return null;
        return GetError(ret);
    }

    /// <summary>
    ///     Remove the share from cache.
    /// </summary>
    /// <returns>Null if successful, otherwise error message.</returns>
    public static string DisconnectFromShare(string uri, bool force)
    {
        //remove the share
        var ret = WNetCancelConnection(uri, force);

        //Check for errors
        if (ret == NO_ERROR)
            return null;
        return GetError(ret);
    }

    #region P/Invoke Stuff

    [DllImport("Mpr.dll")]
    private static extern int WNetUseConnection(
        IntPtr hwndOwner,
        NETRESOURCE lpNetResource,
        string lpPassword,
        string lpUserID,
        int dwFlags,
        string lpAccessName,
        string lpBufferSize,
        string lpResult
    );

    [DllImport("Mpr.dll")]
    private static extern int WNetCancelConnection(
        string lpName,
        bool fForce
    );

    [StructLayout(LayoutKind.Sequential)]
    private class NETRESOURCE
    {
        public int dwDisplayType = 0;
        public int dwScope = 0;
        public int dwType;
        public int dwUsage = 0;
        public string lpComment = "";
        public string lpLocalName = "";
        public string lpProvider = "";
        public string lpRemoteName = "";
    }

    #region Consts

    private const int RESOURCETYPE_DISK = 0x00000001;
    private const int CONNECT_UPDATE_PROFILE = 0x00000001;

    #endregion

    #region Errors

    private const int NO_ERROR = 0;

    private const int ERROR_ACCESS_DENIED = 5;
    private const int ERROR_ALREADY_ASSIGNED = 85;
    private const int ERROR_BAD_DEVICE = 1200;
    private const int ERROR_BAD_NET_NAME = 67;
    private const int ERROR_BAD_PROVIDER = 1204;
    private const int ERROR_CANCELLED = 1223;
    private const int ERROR_EXTENDED_ERROR = 1208;
    private const int ERROR_INVALID_ADDRESS = 487;
    private const int ERROR_INVALID_PARAMETER = 87;
    private const int ERROR_INVALID_PASSWORD = 1216;
    private const int ERROR_MORE_DATA = 234;
    private const int ERROR_NO_MORE_ITEMS = 259;
    private const int ERROR_NO_NET_OR_BAD_PATH = 1203;
    private const int ERROR_NO_NETWORK = 1222;
    private const int ERROR_SESSION_CREDENTIAL_CONFLICT = 1219;

    private const int ERROR_BAD_PROFILE = 1206;
    private const int ERROR_CANNOT_OPEN_PROFILE = 1205;
    private const int ERROR_DEVICE_IN_USE = 2404;
    private const int ERROR_NOT_CONNECTED = 2250;
    private const int ERROR_OPEN_FILES = 2401;

    private struct ErrorClass
    {
        public readonly int num;
        public readonly string message;

        public ErrorClass(int num, string message)
        {
            this.num = num;
            this.message = message;
        }
    }

    private static readonly ErrorClass[] ERROR_LIST =
    {
        new ErrorClass(ERROR_ACCESS_DENIED, "Error: Access Denied"),
        new ErrorClass(ERROR_ALREADY_ASSIGNED, "Error: Already Assigned"),
        new ErrorClass(ERROR_BAD_DEVICE, "Error: Bad Device"),
        new ErrorClass(ERROR_BAD_NET_NAME, "Error: Bad Net Name"),
        new ErrorClass(ERROR_BAD_PROVIDER, "Error: Bad Provider"),
        new ErrorClass(ERROR_CANCELLED, "Error: Cancelled"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"),
        new ErrorClass(ERROR_INVALID_ADDRESS, "Error: Invalid Address"),
        new ErrorClass(ERROR_INVALID_PARAMETER, "Error: Invalid Parameter"),
        new ErrorClass(ERROR_INVALID_PASSWORD, "Error: Invalid Password"),
        new ErrorClass(ERROR_MORE_DATA, "Error: More Data"),
        new ErrorClass(ERROR_NO_MORE_ITEMS, "Error: No More Items"),
        new ErrorClass(ERROR_NO_NET_OR_BAD_PATH, "Error: No Net Or Bad Path"),
        new ErrorClass(ERROR_NO_NETWORK, "Error: No Network"),
        new ErrorClass(ERROR_BAD_PROFILE, "Error: Bad Profile"),
        new ErrorClass(ERROR_CANNOT_OPEN_PROFILE, "Error: Cannot Open Profile"),
        new ErrorClass(ERROR_DEVICE_IN_USE, "Error: Device In Use"),
        new ErrorClass(ERROR_EXTENDED_ERROR, "Error: Extended Error"),
        new ErrorClass(ERROR_NOT_CONNECTED, "Error: Not Connected"),
        new ErrorClass(ERROR_OPEN_FILES, "Error: Open Files"),
        new ErrorClass(ERROR_SESSION_CREDENTIAL_CONFLICT, "Error: Credential Conflict")
    };

    private static string GetError(int errNum)
    {
        foreach (var er in ERROR_LIST)
            if (er.num == errNum)
                return er.message;
        return "Error: Unknown, " + errNum;
    }

    #endregion

    #endregion
}

public class ConnectToSharedFolder : IDisposable
{
    public enum ResourceDisplaytype
    {
        Generic = 0x0,
        Domain = 0x01,
        Server = 0x02,
        Share = 0x03,
        File = 0x04,
        Group = 0x05,
        Network = 0x06,
        Root = 0x07,
        Shareadmin = 0x08,
        Directory = 0x09,
        Tree = 0x0a,
        Ndscontainer = 0x0b
    }

    public enum ResourceScope
    {
        Connected = 1,
        GlobalNetwork,
        Remembered,
        Recent,
        Context
    }

    public enum ResourceType
    {
        Any = 0,
        Disk = 1,
        Print = 2,
        Reserved = 8
    }

    private readonly string _networkName;

    public ConnectToSharedFolder(string networkName, NetworkCredential credentials)
    {
        _networkName = networkName;

        var netResource = new NetResource
        {
            Scope = ResourceScope.GlobalNetwork,
            ResourceType = ResourceType.Disk,
            DisplayType = ResourceDisplaytype.Share,
            RemoteName = networkName
        };

        var userName = string.IsNullOrEmpty(credentials.Domain)
            ? credentials.UserName
            : string.Format(@"{0}\{1}", credentials.Domain, credentials.UserName);

        var result = WNetAddConnection2(
            netResource,
            credentials.Password,
            userName,
            0);

        if (result != 0) throw new Win32Exception(result, "Error connecting to remote share");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    ~ConnectToSharedFolder()
    {
        Dispose(false);
    }

    protected virtual void Dispose(bool disposing)
    {
        WNetCancelConnection2(_networkName, 0, true);
    }

    [DllImport("mpr.dll")]
    private static extern int WNetAddConnection2(NetResource netResource,
        string password, string username, int flags);

    [DllImport("mpr.dll")]
    private static extern int WNetCancelConnection2(string name, int flags,
        bool force);

    [StructLayout(LayoutKind.Sequential)]
    public class NetResource
    {
        public string Comment;
        public ResourceDisplaytype DisplayType;
        public string LocalName;
        public string Provider;
        public string RemoteName;
        public ResourceType ResourceType;
        public ResourceScope Scope;
        public int Usage;
    }
}
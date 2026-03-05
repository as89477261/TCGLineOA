using System;
using System.Web;
using System.Web.SessionState;

public class SessionManager
{
    private readonly HttpSessionState _session;

    private readonly SessionEnum? _sessionKey;


    public SessionManager()
    {
        _session = HttpContext.Current.Session;
    }

    public SessionManager(SessionEnum sessionKey)
        : this()
    {
        _sessionKey = sessionKey;
    }

    private string SessionName
    {
        get
        {
            if (_sessionKey == null) throw new NullReferenceException("No sessionKey provided at the constructor");
            return _sessionKey.ToString();
        }
    }

    public string GetSessionId()
    {
        return _session.SessionID;
    }

    public bool HasAnySessions()
    {
        if (_session != null) return _session.Count > 0;
        return false;
    }

    public void RemoveAll()
    {
        _session.RemoveAll();
    }

    public void AbandonSessions()
    {
        _session.Abandon();
    }


    #region Depends on SessionKey provied using constructor

    public bool DoesKeyExist()
    {
        if (!HasAnySessions()) return false;

        var exist = false;
        for (var i = 0; i < _session.Count; i++)
        {
            exist = _session.Keys[i] == SessionName;
            if (exist)
            {
                if (_session[SessionName] != null) break;
                return false;
            }
        }

        return exist;
    }

    public bool DoesKeyExistThenRemove()
    {
        if (!HasAnySessions()) return false;

        var exist = false;
        for (var i = 0; i < _session.Count; i++)
        {
            exist = _session.Keys[i] == SessionName;
            if (exist) Remove();
        }

        return exist;
    }

    public bool IsNull()
    {
        return _session[SessionName] == null;
    }

    public void SetNull()
    {
        _session[SessionName] = null;
    }

    public TSource Get<TSource>()
    {
        if (IsNull()) throw new Exception(string.Format("The session with key '{0}' is null", SessionName));
        return (TSource)_session[SessionName];
    }

    public void Add<TSource>(TSource model)
    {
        if (DoesKeyExist())
            throw new Exception(string.Format("The session key '{0}' is already been used, try using another key",
                SessionName));
        _session.Add(SessionName, model);
    }

    public void Replace<TSource>(TSource model)
    {
        if (!DoesKeyExist())
            throw new Exception(string.Format("The session key '{0}' is not been used yet", SessionName));

        if (!IsNull() && model.GetType() != _session[SessionName].GetType())
            throw new Exception(
                string.Format("The old data type of session key '{0}' is not matching with the new data type",
                    SessionName));
        _session[SessionName] = model;
    }

    public void Remove()
    {
        if (!DoesKeyExist())
            throw new Exception(
                string.Format("The session with the key '{0}' is already been removed, or not used yet", SessionName));
        _session.Remove(SessionName);
    }

    #endregion
}

public enum SessionEnum
{
    LogOn,
    Permission,
    LogInName,
    LogInTime,
    Language,
    RoundActive,

    uid
}
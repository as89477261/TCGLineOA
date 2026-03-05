using System;
using System.Collections.Generic;
using System.Web;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

/// <summary>
///     Cookie helper class.
/// </summary>
public static class CookieManager
{
    private static HttpContext Context => HttpContext.Current;

    public static void Set1(string key, string value, int expiresAsDays = 30, bool isHttp = false, string domain = null,
        string path = null, bool secure = false)
    {
        if (string.IsNullOrEmpty(key))
            return;

        var encodedKey = HttpUtility.UrlEncode(key);

        var encodedValue = !string.IsNullOrEmpty(value)
            ? HttpUtility.UrlEncode(value)
            : string.Empty;

        var c = new HttpCookie(encodedKey)
        {
            Value = encodedValue,
            Expires = DateTime.Now.AddDays(expiresAsDays),
            HttpOnly = isHttp,
            Secure = secure
        };

        if (!string.IsNullOrEmpty(domain))
            c.Domain = domain;

        if (!string.IsNullOrEmpty(path))
            c.Path = path;

        Context.Response.Cookies.Add(c);
    }

    public static string Get1(string key, bool isHttp = false, string domain = null, string path = null,
        bool secure = false)
    {
        var returnValue = string.Empty;

        if (string.IsNullOrEmpty(key))
            return returnValue;

        var decodedKey = HttpUtility.UrlDecode(key.ToLower());
        var c = Context.Request.Cookies[decodedKey];
        if (c == null)
            return returnValue;

        if (isHttp != c.HttpOnly)
            return returnValue;

        if (!string.IsNullOrEmpty(domain) && !string.Equals(c.Domain, domain, StringComparison.Ordinal))
            return returnValue;

        if (!string.IsNullOrEmpty(path) && !string.Equals(c.Path, path, StringComparison.Ordinal))
            return returnValue;

        if (!string.IsNullOrEmpty(c.Value))
            returnValue = HttpUtility.UrlDecode(c.Value).Trim();

        return returnValue;
    }

    public static bool Exists(string key, bool isHttp = false, string domain = null, string path = null,
        bool secure = false)
    {
        if (string.IsNullOrEmpty(key))
            return false;

        var decodedKey = HttpUtility.UrlDecode(key);
        var c = Context.Request.Cookies[decodedKey];

        if (c == null)
            return false;

        if (isHttp != c.HttpOnly)
            return false;

        if (!string.IsNullOrEmpty(domain) && !string.Equals(c.Domain, domain, StringComparison.Ordinal))
            return false;

        if (!string.IsNullOrEmpty(path) && !string.Equals(c.Path, path, StringComparison.Ordinal))
            return false;

        return true;
    }

    //public static void Delete(string key, bool isHttp = false, string domain = null, string path = null, bool secure = false)
    //{
    //    if (!Exists(key, isHttp, domain, path, secure))
    //        return;

    //    Set(key, null, -10, isHttp, domain, path, secure);
    //}

    //public static void DeleteAllCookies(bool isHttp = false, string domain = null, string path = null, bool secure = false, bool deleteServerCookies = false)
    //{
    //    for (var i = 0; i <= Context.Request.Cookies.Count - 1; i++)
    //    {
    //        if (Context.Request.Cookies[i] != null)
    //            Delete(Context.Request.Cookies[i].Name, isHttp, domain, path, secure);
    //    }

    //    if (deleteServerCookies)
    //        Context.Request.Cookies.Clear();
    //}

    public static string GetEncryptCookie(string group, string key, string code)
    {
        var lineOACookie = Get1(group);
        var data = AESEncrytDecry.DecryptStringAES(lineOACookie, code);

        var obj = JObject.Parse(data);

        var value = (string)obj.SelectToken(key);

        return value;
    }

    public static void SetEncryptListCookie(string group, Dictionary<string, string> lstValue, string code)
    {
        var lineOACookie = Get1(group);
        var data = AESEncrytDecry.DecryptStringAES(lineOACookie, code);

        var obj = JObject.Parse(data);
        foreach (var item in lstValue)
        {
            var isExist = obj.ContainsKey(item.Key);
            if (isExist)
                obj[item.Key] = item.Value;
            //string bufferValue = (string)obj.SelectToken(item.Key);
            //if (bufferValue != null)
            //{
            //}
            //else
            //{
            //}
            else
                obj.Add(item.Key, item.Value);
        }

        var bufferEncryptedData = AESEncrytDecry.EncryptStringAES(obj.ToString(Formatting.None), code);
        Set1(group, bufferEncryptedData);
    }

    public static void SetEncryptCookie(string group, string key, string value, string code)
    {
        var lineOACookie = Get1(group);
        var data = AESEncrytDecry.DecryptStringAES(lineOACookie, code);

        var obj = JObject.Parse(data);
        LocalLogManager.Logger("Cookie Manager : " + obj);
               
        var bufferData = obj[key];
        if (bufferData != null)
        {
            obj[key] = value;
        }
        else
        {
            obj.Add(key, value);
        }

        //var bufferValue = (string)obj.SelectToken(key);
        //LocalLogManager.Logger("Cookie Manager : " + bufferValue);
        //if (!string.IsNullOrEmpty(bufferData))
        //{
        //    obj[key] = value;
        //}
        //else
        //{
        //    obj.Add(key, value);
        //}

        var bufferEncryptedData = AESEncrytDecry.EncryptStringAES(obj.ToString(Formatting.None), code);
        Set1(group, bufferEncryptedData);
    }
}

using CoreUtility;
using DataModel.Models.Network;
using Newtonsoft.Json;
using OPEN_API_DL.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;

public class BaseApi : ApiController
{

    public BaseApi()
    {
    }


    public string GetAppSetting(string key)
    {
        return ConfigurationManager.AppSettings[key];
    }

    protected void ValidateHeader()
    {
        try
        {
            if (ConfigurationManager.AppSettings["IsDebugByPassValidateHeader"] == "1")
            {
                return;
            }

            Request.Headers.TryGetValues("Authorization", out var headerToken);
            var token = headerToken.First();

            if (!string.IsNullOrEmpty(token))
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferUid = CryptographyManager.Decrypt(token);

                    if (uid != bufferUid)
                    {
                        throw new Exception("Token Not Match.");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            LocalLogManager.Logger("Error ValidateHeader : " + ex.Message);
        }
    }

    protected void ValidatePersonalToken()
    {
        try
        {
            var result = false;


            Request.Headers.TryGetValues("Authorization", out var headerToken);
            var token = headerToken.First();

            if (!string.IsNullOrEmpty(token))
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {
                    var bufferUid = CryptographyManager.Decrypt(token);

                    if (uid != bufferUid)
                    {
                        throw new Exception("Token Not Match.");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            LocalLogManager.Logger("Error ValidateHeader : " + ex.Message);
        }
    }

    protected void ValidateMacToken(ClientNetworkModel httpObj)
    {
        try
        {
            var result = false;

            if (!string.IsNullOrEmpty(httpObj.MacAddress))
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                var lToken = CookieManager.GetEncryptCookie("lineoa", "LToken", GetAppsetting("APIPartialCode"));

                if (uid != null)
                {
                    var persisToken = CryptographyManager.GetMd5Hash(httpObj.MacAddress + uid + GetAppsetting("APIPartialCode"));
                    LocalLogManager.Logger("ValidateMacToken Compare with " + lToken + " and " + persisToken);

                    if (lToken != persisToken)
                    {
                        throw new Exception("Token Not Match.");
                    }
                }
            }
        }
        catch (Exception ex)
        {
            LocalLogManager.Logger("Error ValidateMacToken : " + ex.Message);
        }
    }

    protected void ValidateFixHeader()
    {
        try
        {
            if (ConfigurationManager.AppSettings["IsDebugByPassValidateHeader"] == "1")
            {
                return;
            }
            Request.Headers.TryGetValues("Authorization", out var headerToken);
            var token = headerToken.First();

            if (!string.IsNullOrEmpty(token))
            {
                var uid = CookieManager.GetEncryptCookie("lineoa", "uid", GetAppsetting("APIPartialCode"));
                if (uid != null)
                {

                    if (uid != token)
                    {
                        throw new Exception("Token Not Match.");
                    }

                }
            }
        }
        catch (Exception ex)
        {
            LocalLogManager.Logger("Error ValidateHeader : " + ex.Message);

        }
    }
    protected string GetAppsetting(string configName)
    {
        return ConfigurationManager.AppSettings[configName];
    }
    protected IHttpActionResult GenResponse(Object obj)
    {
        var baseObj = (BaseObject)obj;
        switch (baseObj.RESULT_CODE)
        {
            case "200":
                return Ok(obj);
            case "400":
                return Ok(obj);
            case "500":
                return BadRequest();
            default:
                return BadRequest();
        }

    }
    protected IHttpActionResult GenResponseTCC(Object obj)
    {
        var baseObj = (RespondAPIMemberStatusBYSModel)obj;
        switch (baseObj.Code)
        {
            case "200":
                return Ok(obj);
            case "350":
                return Ok(obj);
            case "500":
                return BadRequest();
            default:
                return BadRequest();
        }

    }

    protected IHttpActionResult GenResponseTCCAddMember(Object obj)
    {
        var baseObj = (ResponseModelAddMember)obj;
        switch (baseObj.Code)
        {
            case "200":
                return Ok(obj);
            case "350":
                return Ok(obj);
            case "500":
                return BadRequest();
            default:
                return BadRequest();
        }
    }

    protected IHttpActionResult GenJsonResponse<T>(Object obj)
    {
        var baseObj = (BaseModel<T>)obj;
        switch (baseObj.RESULT_CODE)
        {
            case "200":
                return Ok(baseObj.RESULT_OBJ);
            case "400":
                return Ok(baseObj.RESULT_OBJ);
            case "500":
                return BadRequest(baseObj.RESULT_MESSAGE);
            default:
                return StatusCode(System.Net.HttpStatusCode.BadRequest);
        }
    }

    public string GetErrorMessage(ModelStateDictionary modelState)
    {
        var message = string.Join(Environment.NewLine, modelState.Values
                                           .SelectMany(v => v.Errors)
                                           .Select(e => e.ErrorMessage));
        return message;
    }

    public ClientNetworkModel GetRequestNetworkInfo()
    {
        var result = new ClientNetworkModel();
        var ipAddress = "";
        var macAddress = "";

        HTTPManager.GetIpAddress1(HttpContext.Current, out ipAddress);
        if (ipAddress == "")
        {
            HTTPManager.GetIpAddress2(HttpContext.Current, out ipAddress);
        }

        macAddress = HTTPManager.GetMACAddress1();
        if (macAddress == "")
        {
            macAddress = HTTPManager.GetMACAddress2();
        }

        result.MacAddress = macAddress;
        result.IPAddress = ipAddress;

        return result;
    }
}


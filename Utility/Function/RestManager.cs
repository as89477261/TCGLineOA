using System;
using System.Net;
using System.Text;

public class RestManager
{
    private readonly string DATA;
    private readonly string URL;

    private HttpWebRequest webRequest;

    public RestManager(string dataURL = "https://sub.domain.com/objects.json?api_key=123",
        string dataData = @"{""object"":{""name"":""Name""}}")
    {
        URL = dataURL;
        DATA = dataData;
    }

    public void CreateObject()
    {
        webRequest = (HttpWebRequest)WebRequest.Create(URL);
        webRequest.Method = "POST";
        //request.Headers["Content-type"] = "text/xml;charset=utf-8";
        webRequest.ContentType = "application/json";
        webRequest.ContentLength = DATA.Length;


        var bytes = Encoding.UTF8.GetBytes(DATA);
        webRequest.ContentLength = bytes.Length;

        using (var writer = webRequest.GetRequestStream())
        {
            writer.Write(bytes, 0, bytes.Length);
        }

        //request.BeginGetRequestStream(new AsyncCallback(GetRequestStreamCallback), request);
        //webRequest.BeginGetResponse(new AsyncCallback(FinishWebRequest), null);
        //return "";


        //try
        //{
        //    WebResponse webResponse = request.GetResponse();
        //    using (Stream webStream = webResponse.GetResponseStream() ?? Stream.Null)
        //    using (StreamReader responseReader = new StreamReader(webStream))
        //    {
        //        string response = responseReader.ReadToEnd();
        //        return response;
        //    }
        //}
        //catch (Exception e)
        //{
        //    return "";
        //}
    }

    private void FinishWebRequest(IAsyncResult result)
    {
        webRequest.EndGetResponse(result);
    }
}
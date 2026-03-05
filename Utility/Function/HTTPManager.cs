using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;

namespace CoreUtility
{
    public class HTTPManager
    {
        public static string HttpGet(string URI)
        {
            var req = WebRequest.Create(URI);
            // req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            var result = string.Empty;
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                result = reader.ReadToEnd().Trim();
                reader.Close();
                dataStream.Close();
            }

            return result;
        }

        public static async Task<string> HttpGetAsync(string URI)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    HttpResponseMessage response = await client.GetAsync(URI);

                    if (response.IsSuccessStatusCode)
                    {
                        return await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        // Handle HTTP error responses here if needed
                        Console.WriteLine($"HTTP Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HttpRequestException: {ex.Message}");
                // Handle or log the exception as needed
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                // Handle or log the exception as needed
                return null;
            }
        }
        public static async Task<string> HttpGetHeaderAsync(string URI, string Headers)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, URI);
                //request.Content = new StringContent("");
                //var content = new StringContent("");
                //request.Content.Headers.ContentType.MediaType.Equals("application/json"); 

                //request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                request.Headers.Add("accept", "*/*");
                request.Headers.Add("Authorization", Headers);

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                Console.WriteLine(await response.Content.ReadAsStringAsync());
                var result = await response.Content.ReadAsStringAsync();
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
                return null;
            }
        }

        public static T HttpGet<T>(string URI)
        {
            var req = WebRequest.Create(URI);
            // req.Proxy = new System.Net.WebProxy(ProxyString, true); //true means no proxy
            var result = string.Empty;
            using (var response = (HttpWebResponse)req.GetResponse())
            {
                var dataStream = response.GetResponseStream();
                var reader = new StreamReader(dataStream);
                result = reader.ReadToEnd().Trim();
                reader.Close();
                dataStream.Close();
            }

            return JsonConvert.DeserializeObject<T>(result);
        }

        public static string HttpPost(string url, Dictionary<string, string> header, string requestTextJson)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = 1000000;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                foreach (var item in header) httpWebRequest.Headers.Add(item.Key, item.Value);
                //httpWebRequest.Headers.Add("Authorization", "Bearer " + lineAccessToken);
                LocalLogManager.Logger("UTILITY : Add Header Success");
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(requestTextJson);
                }

                LocalLogManager.Logger("UTILITY : Add Body Success");
                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                LocalLogManager.Logger("UTILITY : http result is " + httpResponse.StatusCode + " - " + httpResponse);
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();

                    return result;
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("HttpPost : EXception is - " + ex.GetBaseException().Message);
                throw;
            }
        }

        public static byte[] DownloadAFileViaPost(string url, Dictionary<string, string> header, string jsonBody)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                    (sender, certificate, chain, sslPolicyErrors) => true;

                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.Timeout = 1000000;
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                foreach (var item in header) httpWebRequest.Headers.Add(item.Key, item.Value);

                LocalLogManager.Logger("UTILITY : Add Header Success");
                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    streamWriter.Write(jsonBody);
                }

                LocalLogManager.Logger("UTILITY : Add Body Success");
                using (var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    LocalLogManager.Logger("UTILITY : http result is " + httpResponse.StatusCode + " - " +
                                           httpResponse);

                    using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                    using (var memstream = new MemoryStream())
                    {
                        streamReader.BaseStream.CopyTo(memstream);
                        return memstream.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("DownloadAFileViaPost : EXception is - " + ex.GetBaseException().Message);
                throw;
            }
        }

        public static string HttpPost(string URI, IDictionary<string, string> header,
            IDictionary<string, string> values)
        {
            try
            {
                ServicePointManager.ServerCertificateValidationCallback +=
                   (sender, certificate, chain, sslPolicyErrors) => true;

                using (var wc = new WebClient())
                {
                    var data = new NameValueCollection();
                    foreach (var item in header) wc.Headers[item.Key] = item.Value;

                    foreach (var item in values) data[item.Key] = item.Value;

                    var HtmlResult = wc.UploadValues(URI, "POST", data);
                    var responseString = Encoding.UTF8.GetString(HtmlResult);
                    return responseString;
                }
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("HttpPost : EXception is - " + ex.GetBaseException().Message);
                return "";
            }
        }

        public static async Task<string> HttpPostAsync(string URI, IDictionary<string, string> header, IDictionary<string, string> values)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    // Add headers
                    foreach (var item in header)
                    {
                        httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
                    }

                    // Convert values to form content
                    var formContent = new FormUrlEncodedContent(values);

                    // Perform the POST request asynchronously
                    var response = await httpClient.PostAsync(URI, formContent);

                    // Ensure the request was successful before reading the content
                    response.EnsureSuccessStatusCode();

                    // Read and return the response content
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                LocalLogManager.Logger("HttpPostAsync : HttpRequestException - " + ex.Message);
                return "";
            }
            catch (Exception ex)
            {
                LocalLogManager.Logger("HttpPostAsync : Exception - " + ex.GetBaseException().Message);
                return "";
            }
        }


        public static T HttpPost<T>(string URI, IDictionary<string, string> header, IDictionary<string, string> values)
        {
            using (var wc = new WebClient())
            {
                try
                {
                    ServicePointManager.ServerCertificateValidationCallback +=
                  (sender, certificate, chain, sslPolicyErrors) => true;

                    wc.Headers[HttpRequestHeader.ContentType] = "application/json";
                    var data = new NameValueCollection();
                    foreach (var item in header) wc.Headers[item.Key] = item.Value;

                    var bufferJson = GenJsonString(values);
                    var dataByte = Encoding.Default.GetBytes(bufferJson);

                    var HtmlResult = wc.UploadData(URI, "POST", dataByte);
                    var responseString = Encoding.UTF8.GetString(HtmlResult);
                    var result = JsonConvert.DeserializeObject<T>(responseString);
                    return result;
                }
                catch (Exception ex)
                {
                    LocalLogManager.Logger("HttpPost : EXception is - " + ex.GetBaseException().Message);
                    throw;
                }
            }
        }

        public static T HttpPostWithForm<T>(string URI, IDictionary<string, string> header, NameValueCollection values)
        {
            using (var wc = new WebClient())
            {
                var HtmlResult = new byte[0];
                try
                {
                    wc.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
                    var data = new NameValueCollection();
                    foreach (var item in header) wc.Headers[item.Key] = item.Value;

                    HtmlResult = wc.UploadValues(URI, "POST", values);
                    var responseString = Encoding.UTF8.GetString(HtmlResult);
                    var result = JsonConvert.DeserializeObject<T>(responseString);
                    return result;
                }
                catch (Exception ex)
                {
                    var responseString = Encoding.UTF8.GetString(HtmlResult);
                    throw;
                }
            }
        }

        public static T HttpPost<T>(string URI, IDictionary<string, string> header, string values)
        {
            using (var wc = new WebClientExtension())
            {

                foreach (var item in header) wc.Headers[item.Key] = item.Value;
                wc.Headers[HttpRequestHeader.ContentType] = "application/json;";
                var HtmlResult = wc.UploadString(URI, "POST", values);
                var result = JsonConvert.DeserializeObject<T>(HtmlResult);
                return result;
            }
        }

        public static string HttpPostWithForm2(string URI, IDictionary<string, string> header, string values)
        {
            var encoding = new ASCIIEncoding();

            var data = encoding.GetBytes(values);

            var myRequest =
                (HttpWebRequest)WebRequest.Create(URI);
            myRequest.ProtocolVersion = HttpVersion.Version11;
            myRequest.Method = "POST";
            myRequest.ContentType = "application/x-www-form-urlencoded";
            myRequest.ContentLength = data.Length;
            var newStream = myRequest.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();

            var response = myRequest.GetResponse();
            var responseStream = response.GetResponseStream();
            var responseReader = new StreamReader(responseStream);
            responseReader.Close();
            response.Close();

            return responseReader.ReadToEnd();
        }

        public static async Task<T> HttpPostWithForm3<T>(string URI, IDictionary<string, string> header,
            IDictionary<string, string> values)
        {
            var client = new HttpClient();
            var res = client.PostAsync(URI, new FormUrlEncodedContent(values));
            var content = await res.Result.Content.ReadAsStringAsync();

            //string responseString = Encoding.UTF8.GetString(content);
            var result = JsonConvert.DeserializeObject<T>(content);
            return result;
        }

        public static async Task<T> HttpPostWithForm4<T>(string URI, T values) where T : new()
        {

            //var client = new HttpClient();
            //var request = new HttpRequestMessage(HttpMethod.Post, URI);
            //var bufferInput = JsonConvert.SerializeObject(values);
            //var content = new StringContent(bufferInput, null, "application/json");
            //request.Content = content;
            //var response = await client.SendAsync(request);
            //response.EnsureSuccessStatusCode();
            //Console.WriteLine(await response.Content.ReadAsStringAsync());
            //string apiResponse = await response.Content.ReadAsStringAsync();
            //return JsonConvert.DeserializeObject<T>(apiResponse);
            //return response.Content;


            var httpClientHandler = new HttpClientHandler();
            httpClientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, sslPolicyErrors) => { return true; };
            var result = new T();
            try
            {
                using (var httpClient = new HttpClient(httpClientHandler))
                {
                    var responsetest = await httpClient.PostAsJsonAsync(URI, values);

                    using (var response = await httpClient.PostAsJsonAsync(URI, values))
                    {
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();

                            result = JsonConvert.DeserializeObject<T>(apiResponse);
                        }
                        else
                        {
                            // Handle error here if needed
                            throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return result;

        }


        public static string GenJsonString(IDictionary<string, string> values)
        {
            var result = "{";
            var i = 0;
            foreach (var item in values)
            {
                var buffer = "\"" + item.Key + "\":\"" + item.Value + "\"";
                i += 1;
                if (i < values.Count) buffer += ",";

                result += buffer;
            }

            result += "}";
            return result;
        }

        public static T HttpPostFormData<T>(string URI, IDictionary<string, string> header, IDictionary<string, string> values)
        {
            using (WebClient wc = new WebClient())
            {
                var data = new NameValueCollection();
                foreach (var item in header)
                {
                    wc.Headers[item.Key] = item.Value;
                }

                foreach (var item in values)
                {
                    data[item.Key] = item.Value;
                }

                // wc.Headers.Add("Content-Type", "multipart/form-data");
                var HtmlResult = wc.UploadValues(URI, "POST", data);
                string responseString = Encoding.UTF8.GetString(HtmlResult);
                var result = JsonConvert.DeserializeObject<T>(responseString);
                return result;
            }
        }


        public static void GetIpAddress1(HttpContext request, out string ipAdd)
        {
            ipAdd = request.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (string.IsNullOrEmpty(ipAdd))
            {
                ipAdd = request.Request.ServerVariables["REMOTE_ADDR"];
            }

        }

        public static void GetIpAddress2(HttpContext request, out string userip)
        {
            userip = request.Request.UserHostAddress;
            if (request.Request.UserHostAddress != null)
            {
                Int64 macinfo = new Int64();
                string macSrc = macinfo.ToString("X");
                if (macSrc == "0")
                {
                    if (userip == "127.0.0.1")
                    {
                        request.Response.Write("visited Localhost!");
                    }
                }
            }
        }

        public static string GetMACAddress1()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
            String sMacAddress = string.Empty;
            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty && adapter.OperationalStatus == OperationalStatus.Up)// only return MAC Address from first card
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        public static string GetMACAddress2()
        {
            try
            {

           
            ManagementObjectSearcher objMOS = new ManagementObjectSearcher("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMOS.Get(); 
            string MACAddress = String.Empty;
            foreach (ManagementObject objMO in objMOC)
            {
                if (MACAddress == String.Empty) // only return MAC Address from first card
                {
                    MACAddress = objMO["MacAddress"].ToString();
                }
                objMO.Dispose();
            }
            MACAddress = MACAddress.Replace(":", "");
            return MACAddress;
            }
            catch (Exception ex)
            {

                return "";
            }
        }
        public static async Task<string> HttpGetWithHeadersAsync(string uri, Dictionary<string, string> headers)
        {
            using (var client = new HttpClient())
            using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
            {
                try
                {
                    if (headers != null)
                    {
                        foreach (var header in headers)
                        {
                            request.Headers.Add(header.Key, header.Value);
                        }
                    }

                    using (var response = await client.SendAsync(request))
                    {
                        response.EnsureSuccessStatusCode();
                        return await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Exception: {ex.Message}");
                    return null;
                }
            }
        }

    }
}
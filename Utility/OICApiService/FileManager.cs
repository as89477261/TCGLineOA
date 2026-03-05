using System;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

public class FileManager
{
    public string RootPath { get; set; }
    public string Folder { get; set; }
    public string SubFolder { get; set; }


    public static void SaveACopyfileToServer(string filePath, string savePath)
    {
        var directory = Path.GetDirectoryName(savePath).Trim();
        var username = "loginusername";
        var password = "loginpassword";
        var filenameToSave = Path.GetFileName(savePath);

        if (!directory.EndsWith("\\"))
            filenameToSave = "\\" + filenameToSave;

        var command = "NET USE " + directory + " /delete";
        ExecuteCommand(command, 5000);

        command = "NET USE " + directory + " /user:" + username + " " + password;
        ExecuteCommand(command, 5000);

        command = " copy \"" + filePath + "\"  \"" + directory + filenameToSave + "\"";

        ExecuteCommand(command, 5000);


        command = "NET USE " + directory + " /delete";
        ExecuteCommand(command, 5000);
    }

    public static int ExecuteCommand(string command, int timeout)
    {
        var processInfo = new ProcessStartInfo("cmd.exe", "/C " + command)
        {
            CreateNoWindow = true,
            UseShellExecute = false,
            WorkingDirectory = "C:\\"
        };

        var process = Process.Start(processInfo);
        process.WaitForExit(timeout);
        var exitCode = process.ExitCode;
        process.Close();
        return exitCode;
    }

    public async Task<bool> UploadFileAsync(string baseUrl, byte[] file, string pathFile, string newName)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var content = new MultipartFormDataContent();
            var fileContent = new StreamContent(new MemoryStream(file));
            content.Add(fileContent, "file", newName);
            content.Add(new StringContent(pathFile, Encoding.UTF8), "pathFile");
            content.Add(new StringContent(newName, Encoding.UTF8), "fileName");

            var apiResult = await client.PostAsync("file/upload", content);
            if (apiResult.IsSuccessStatusCode)
                return true;
            return false;
        }
    }

    public async Task<bool> UploadFileBoyAsync(string baseUrl, byte[] file, string pathFile, string fileName)
    {
        try
        {
            var fileExtension = string.Empty;
            var multiContent = new MultipartFormDataContent();
            //var path = DateTime.Now.Year + "/" + guid[0] + "/" + guid[1] + "/" + guid[2] + "/" + guid[3] + "/";
            var obj = new HttpClient();

            var pathParam = pathFile + "/";

            using (var outputFile = new MemoryStream(file))
            {
                var bytes = new ByteArrayContent(outputFile.ToArray());
                var subDir = new StringContent(pathParam);
                multiContent.Add(bytes, "files", fileName);
                multiContent.Add(subDir, "subDirectory");

                obj.BaseAddress = new Uri(baseUrl);

                var filePath = pathFile + fileName;
                var result = obj.PostAsync("upload?subDirectory=" + pathParam, multiContent).Result;

                File.AppendAllText(@"C:\inetpub\wwwroot\APIAGUPLOAD\bin\log.txt",
                    "Method Save File Success" + Environment.NewLine);

                if (result.IsSuccessStatusCode) return true;

                return result.IsSuccessStatusCode;
            }
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    public byte[] DownloadFile(string baseUrl, string pathFile)
    {
        byte[] _data = null;
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(baseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Clear();
            var apiResult = client.PostAsJsonAsync("", new { fileName = pathFile }).Result;
            if (apiResult.IsSuccessStatusCode)
                _data = apiResult.Content.ReadAsByteArrayAsync().Result;
            else
                throw new Exception(apiResult.Content.ReadAsStringAsync().Result);

            return _data;
        }
    }
}
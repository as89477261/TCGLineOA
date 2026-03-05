using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace utility
{
    public class FileManager
    {
        public string GetFileWithPath(string path, string file)
        {
            string WorkingDirectory = HttpContext.Current.Server.MapPath("~/" + path + "");

            string[] pFiles = Directory.GetFiles(WorkingDirectory);

            string pFileList = "";

            for (int i = 0; i < pFiles.Length; i++)
            {
                if (pFiles[i] == file)
                {
                    pFileList = file;
                }

            }

            return (pFileList);
        }
    }

}
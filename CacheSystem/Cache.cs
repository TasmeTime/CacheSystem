using System;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Text;

namespace CacheSystem
{
    public class CacheResponses
    {
        public const string FILE_NOT_CACHED = "FILE_NOT_CACHED";
        public const string FILE_DOWNLOAD_ERROR = "FILE_DOWNLOAD_ERROR";
    }
    public class Cache
    {
        public const string VERSION = "beta0.1";
        private string BASE;
        private string FOLDER_NAME;
        public Exception LastExeption;
        public Cache(string Base,string FolderName)
        {
            FOLDER_NAME = FolderName;
            string tmpPath = Base + "\\" + FolderName;

            if (!Directory.Exists(tmpPath))
            {
                //Console.WriteLine("Directory Does Not Exist");
                Directory.CreateDirectory(tmpPath);
                //Console.WriteLine("Create One, {0}", tmpPath);
            }
            BASE = tmpPath;
        }

        public string isFileCached(string MD5)
        {
            string tmpFilePath = BASE + "\\" + MD5.ToLower();
            if (File.Exists(tmpFilePath))
            {
                //Console.WriteLine("File({0}) Exist , PATH={1}",MD5, tmpFilePath);
                return tmpFilePath;
            }
            else
            {
                //Console.WriteLine("File Does Not Cached Before");
                return "FILE_NOT_CACHED";
            }
        }

        public string DownloadFile(string FileURL,string MD5)
        {
            try
            {
                string res = isFileCached(MD5);
                if (res ==CacheResponses.FILE_NOT_CACHED)
                {
                    WebClient client = new WebClient();
                    string tmpFilePath = BASE + "\\" + MD5.ToLower();
                    client.DownloadFile(new Uri(FileURL), tmpFilePath);
                    //Console.WriteLine("File Downloaded ,PATH={0}", tmpFilePath);
                    return tmpFilePath;
                }
                else
                {
                    return res;
                }
            }catch(Exception ex)
            {
                //Console.WriteLine("ERROR: "+ex.Message);
                LastExeption = ex;
                return CacheResponses.FILE_DOWNLOAD_ERROR;
            }
        }

        public string GetMD5(string filename)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(filename))
                {
                    return BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", String.Empty).ToLower();
                }
            }
        }

    }
}

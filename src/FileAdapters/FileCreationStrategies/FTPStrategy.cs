using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters.FileCreationStrategies
{
    public class FTPStrategy : IFileCreationStrategy
    {
        public FTPStrategy()
        {
            if (ExceptionHandler == null)
            {
                ExceptionHandler = exception => { };
            }
        }
        public Action<Exception> ExceptionHandler { get; set; }
        public string FileName { get; set; }
        public bool Overwrite { get; set; }

        public string Host { get; set; }
        public int Port { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public void WriteData(string data)
        {

            using (WebClient client = new WebClient())
            {
                //client.Credentials = new NetworkCredential(Username, Password);
                //client.w
                //client.UploadFile("ftp://ftpserver.com/target.zip", "STOR", localFilePath);
            }
        }
    }
}

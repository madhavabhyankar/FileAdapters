using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters.FileCreationStrategies
{
    public class FTPStrategy : IFileCreationStrategy, IFTPStrategy
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
        public string Directory { get; set; }
        public void WriteData(string data)
        {

            using (WebClient client = new WebClient())
            {
                client.Credentials = new NetworkCredential(Username, Password);
                var ftpLocation = string.Format(@"ftp://{0}:{1}/{2}/{3}", Host, Port, Directory, FileName);
                using (var stream = client.OpenWrite(ftpLocation))
                {
                    var bytesToWrite = Encoding.ASCII.GetBytes(data);
                    stream.Write(bytesToWrite, 0, bytesToWrite.Length);
                }
            }
        }
    }
}

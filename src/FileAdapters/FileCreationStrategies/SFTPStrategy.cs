using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;

namespace FileAdapters.FileCreationStrategies
{
    public class SFTPStrategy : IFileCreationStrategy, ISFTPStrategy
    {
        
        public SFTPStrategy()
        {
            if (ExceptionHandler == null)
            {
                ExceptionHandler = exception => { };
            }
            Port = 22;
        }
        public Action<Exception> ExceptionHandler { get; set; }
        public string FileName { get; set; }
        public bool Overwrite { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public string Directory { get; set; }
        public int Port { get; set; }
        public void WriteData(string data)
        {
            var pathToWriteTo = string.Format(@"{0}\{1}", Directory, FileName);
            using (var client = new SftpClient(Host,Port,Username,Password))
            {
                client.Connect();
                client.ChangeDirectory(Directory);
                client.BufferSize = 4*1024;
                
                if (client.Exists(pathToWriteTo) && !Overwrite)
                {
                    throw new Exception("File by that name already exists");
                }
                client.WriteAllText(pathToWriteTo, data);
                
            }

        }

        
    }
}

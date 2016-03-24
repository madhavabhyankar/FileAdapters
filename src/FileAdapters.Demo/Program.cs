using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileAdapters.FileCreationStrategies;
using FileAdapters.Implementation;

namespace FileAdapters.Demo
{
    class Program
    {
        public class Demo
        {
            public void Write(Exception ex)
            {
                Console.WriteLine("Exception Caught {0}", ex.Message);
            }
        }
        static void Main(string[] args)
        {
            var filePipeLine = new FilePipeline();
            var demo = new Demo();
            filePipeLine.AddStrategy(new PhysicalLocalDriveStrategy
            {
                FileName = "DemoFile.txt",
                CreateDirectoryIfDoesntExist = false,
                ExceptionHandler = demo.Write,
                Overwrite = true,
                Location = @"C:\FileTransfers\"
            });

            filePipeLine.AddStrategy(new FTPStrategy
            {
                Host = "ftpserver.dummy.com",
                Port = 21,
                ExceptionHandler = demo.Write,
                FileName = "Dummy.txt",
                Directory = "dummerlocation",
                Overwrite = true,
                Username = "smartuser",
                Password = "password"
            });
            filePipeLine.AddStrategy(new SFTPStrategy
            {
                ExceptionHandler = demo.Write,
                FileName = "dummy.txt",
                Directory = @"/Test",
                Port = 22,
                Overwrite = true,
                Password = "password",
                Username = "sftp",
                Host = "dada.com"
            });
            filePipeLine.WriteFile("Dummy!");
        }

    }
}

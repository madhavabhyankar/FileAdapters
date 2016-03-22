# FileAdapters
Create File using Shared location, SFTP and FTP

This library is useful when creating files over SFTP / FTP or physical file share.  You can also chain file creations - i.e. first create a file on the physical drive and then create it on SFTP location.

Usage:
        //Exception handler
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
            //First write to a file on a physical drive
            filePipeLine.AddStrategy(new PhysicalLocalDriveStrategy
            {
                FileName = "DemoFile.txt",
                CreateDirectoryIfDoesntExist = false,
                ExceptionHandler = demo.Write,
                Overwrite = true,
                Location = @"C:\FileTransfers\"
            });
            //Then write to the FTP location
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

            //After the configuration call the write command.
            filePipeLine.WriteFile("Dummy!");
        }
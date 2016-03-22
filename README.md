# FileAdapters
Create File using Shared location, SFTP and FTP

This library is useful when creating files over SFTP / FTP or physical file share.  You can also chain file creations - i.e. first create a file on the physical drive and then create it on SFTP location.

Usage:

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
                FileName = "DemoFile",
                CreateDirectoryIfDoesntExist = false,
                ExceptionHandler = demo.Write,
                Overwrite = true,
                Location = @"C:\ddalkajsldkjf\alksdjlfkajsd\"
            });

            filePipeLine.WriteFile("Dummy!");
        }

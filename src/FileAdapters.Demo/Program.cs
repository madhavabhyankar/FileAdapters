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
                FileName = "DemoFile",
                CreateDirectoryIfDoesntExist = false,
                ExceptionHandler = demo.Write,
                Overwrite = true,
                Location = @"C:\ddalkajsldkjf\alksdjlfkajsd\"
            });

            filePipeLine.WriteFile("Dummy!");
        }

    }
}

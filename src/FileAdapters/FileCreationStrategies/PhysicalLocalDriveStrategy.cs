using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters.FileCreationStrategies
{
    

    public class PhysicalLocalDriveStrategy : IFileCreationStrategy, IPhysicalLocalDriveStrategy
    {
        public PhysicalLocalDriveStrategy()
        {
            if (ExceptionHandler == null)
            {
                ExceptionHandler = exception => { };
            }
        }
        public Action<Exception> ExceptionHandler { get; set; }
        public string FileName { get; set; }
        public string Location { get; set; }
        public bool CreateDirectoryIfDoesntExist { get; set; }
        public bool Overwrite { get; set; }
        public void WriteData(string data)
        {
            if (!Directory.Exists(Location))
            {
                if (CreateDirectoryIfDoesntExist)
                {
                    Directory.CreateDirectory(Location);
                }
                else
                {
                    throw new Exception(string.Format("Path {0} Does not exist.", Location));
                }
            }
            using (var strmWriter = new StreamWriter(new FileStream(Path.Combine(Location, FileName), Overwrite? FileMode.Create :  FileMode.CreateNew)))
            {
                strmWriter.WriteLine(data);
            }

        }
    }
}

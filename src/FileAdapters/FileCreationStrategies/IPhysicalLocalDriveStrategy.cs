using System;

namespace FileAdapters.FileCreationStrategies
{
    public interface IPhysicalLocalDriveStrategy
    {
        Action<Exception> ExceptionHandler { get; set; }
        string FileName { get; set; }
        string Location { get; set; }
        bool CreateDirectoryIfDoesntExist { get; set; }
        bool Overwrite { get; set; }
        void WriteData(string data);
    }
}

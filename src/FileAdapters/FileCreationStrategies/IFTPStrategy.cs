using System;

namespace FileAdapters.FileCreationStrategies
{
    public interface IFTPStrategy
    {
        Action<Exception> ExceptionHandler { get; set; }
        string FileName { get; set; }
        bool Overwrite { get; set; }
        string Host { get; set; }
        int Port { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Directory { get; set; }
        void WriteData(string data);
    }
}
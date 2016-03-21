using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters.FileCreationStrategies
{

    public interface ISFTPStrategy
    {
        Action<Exception> ExceptionHandler { get; set; }
        string FileName { get; set; }
        bool Overwrite { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        string Host { get; set; }
        string Directory { get; set; }
        int Port { get; set; }
        void WriteData(string data);
    }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters
{
    public interface IFileCreationStrategy
    {
        Action<Exception> ExceptionHandler { get; set; }
        string FileName { get; set; }
        bool Overwrite { get; set; }
        void WriteData(string data);
        
    }
}

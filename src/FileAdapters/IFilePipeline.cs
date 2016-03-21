using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters
{
    public interface IFilePipeline
    {
        void AddStrategy(IFileCreationStrategy strategy);
        
        void WriteFile(string data);
    }
}

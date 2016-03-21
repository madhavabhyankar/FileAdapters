using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileAdapters.Implementation
{
    public class FilePipeline : IFilePipeline
    {
        private List<IFileCreationStrategy> strategies; 
        public FilePipeline()
        {
            strategies = new List<IFileCreationStrategy>();
        }
        public void AddStrategy(IFileCreationStrategy strategy)
        {
            strategies.Add(strategy);
        }

        public void WriteFile(string data)
        {
            foreach (var fileCreationStrategy in strategies)
            {
                try
                {
                    fileCreationStrategy.WriteData(data);
                }
                catch (Exception ex)
                {
                    fileCreationStrategy.ExceptionHandler(ex);
                }
            }   
        }
    }
}

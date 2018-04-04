using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class SolutionFinder : IFindable
    {
        private readonly string _findingPath;

        public SolutionFinder(string findingPath)
        {
            _findingPath = findingPath;
        }

        public LinkedList<string> Find()
        {
            var filesList = Directory.GetFiles(_findingPath, "*.sln", SearchOption.TopDirectoryOnly);
            if (filesList.Length == 0) throw new Exception("Solution file doesn't exist in given directory.");
            if (filesList.Length < 1) throw new Exception("Too much *.sln files in given directory.");
            return new LinkedList<string>(filesList);
        }
    }
}

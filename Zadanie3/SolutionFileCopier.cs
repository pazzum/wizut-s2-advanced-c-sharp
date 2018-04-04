using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class SolutionFileCopier : ICopyable
    {
        private readonly string _sourcePath;
        private readonly string _selectedPath;

        public SolutionFileCopier(string sourcePath, string selectedPath)
        {
            _sourcePath = sourcePath;
            _selectedPath = selectedPath;
        }

        public void Copy()
        {                                   
            File.Copy(_sourcePath, GenerateDestinationPath());
        }

        private string GenerateDestinationPath()
        {
            return _selectedPath + "_Copy" + "\\" + _sourcePath.Split('\\').Last();
        }
    }
}

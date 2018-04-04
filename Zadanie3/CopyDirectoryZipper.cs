using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class CopyDirectoryZipper
    {
        private readonly string _copyDirectory;
        private readonly string _rootDirectory;
        private readonly string _archiveName;

        public CopyDirectoryZipper(string selectedPath)
        {
            _copyDirectory = selectedPath + "_Copy";
            _rootDirectory = selectedPath.Substring(0, selectedPath.LastIndexOf('\\'));
            _archiveName = selectedPath.Split('\\').Last() + "_Copy" + ".zip";
        }

        public void Zip()
        {
            ZipFile.CreateFromDirectory(_copyDirectory, GenerateArchivePath());
        }

        private string GenerateArchivePath()
        {
            return _rootDirectory + "\\" + _archiveName;
        }
    }
}

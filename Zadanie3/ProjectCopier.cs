using System.Collections.Generic;
using System.IO;

namespace Zadanie3
{
    class ProjectCopier : ICopyable
    {
        private readonly LinkedList<string> _filesToCopy;
        private readonly string _projectPath;
        private readonly string _selectedPath;

        public ProjectCopier(LinkedList<string> filesToCopy, string projectPath, string selectedPath)
        {
            _filesToCopy = filesToCopy;
            _projectPath = projectPath;
            _selectedPath = selectedPath;
        }

        public void Copy()
        {
            Directory.CreateDirectory(GenerateSolutionCopyDirectoryName());
            Directory.CreateDirectory(GenerateProjectCopyDirectoryName());
            foreach (var fileToCopy in _filesToCopy)
            {
                var lastSlashSeparator = fileToCopy.LastIndexOf("\\");
                string fileName;
                if (lastSlashSeparator != -1)
                {
                    var fileLocation = fileToCopy.Substring(0, lastSlashSeparator);
                    Directory.CreateDirectory(GenerateProjectCopyDirectoryName() + "\\" + fileLocation);
                }
                fileName = fileToCopy;
                
                File.Copy(GenerateSourceFilePath(fileToCopy), GenerateCopiedFilePath(fileName));
            }
        }
        
        private string GenerateSolutionCopyDirectoryName()
        {
            return _selectedPath + "_Copy";
        }

        private string GenerateProjectCopyDirectoryName()
        {
            return GenerateSolutionCopyDirectoryName() + "\\" + _projectPath;
        }
        
        private string GenerateCopiedFilePath(string fileName)
        {
            return GenerateSolutionCopyDirectoryName() + '\\' + _projectPath + "\\" + fileName;
        }

        private string GenerateSourceFilePath(string filePath)
        {
            return _selectedPath + "\\" + _projectPath + '\\' + filePath;
        }
    }
}
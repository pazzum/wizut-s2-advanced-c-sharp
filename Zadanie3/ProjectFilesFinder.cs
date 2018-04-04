using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Zadanie3
{
    class ProjectFilesFinder : IFindable
    {
        private string _projectPath;
        private string _solutionPath;

        public ProjectFilesFinder(string solutionPath, string projectPath)
        {
            projectPath = projectPath.Trim().Trim('"');
            _projectPath = projectPath;
            _solutionPath = solutionPath;
        }

        public LinkedList<string> Find()
        {
            var xmlDoc = new XmlDocument();
            xmlDoc.Load(GenerateProjectFilePath());
            var rootElement = xmlDoc.DocumentElement;
            var filesToCopy = new LinkedList<string>();
            foreach(XmlElement itemGroupNode in rootElement.ChildNodes)
            {
                if(itemGroupNode.Name == "ItemGroup")
                {
                    foreach (XmlElement noneElement in itemGroupNode.ChildNodes)
                    {
                        if (noneElement.Name == "Reference" || noneElement.Name == "BootstrapperPackage") continue;
                        var path = noneElement.Attributes[0].Value;
                        filesToCopy.AddLast(path);
                    }
                }
            }

            filesToCopy.AddLast(GetProjectFileName());

            return filesToCopy;
        }

        private string GenerateProjectFilePath()
        {
            return _solutionPath + '\\' + _projectPath;
        }

        public string GetProjectDirectory()
        {
            var explodedProjectPath = _projectPath.Split('\\');
            return explodedProjectPath[0];
        }

        private string GetProjectFileName()
        {
            var explodedProjectPath = _projectPath.Split('\\');
            return explodedProjectPath.Last();
        }
    }
}

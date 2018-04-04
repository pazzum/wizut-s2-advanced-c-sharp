using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadanie3
{
    class ProjectFinder : IFindable
    {
        private readonly string _solutionFile;

        public ProjectFinder(string solutionFile)
        {
            _solutionFile = solutionFile;
        }

        public LinkedList<string> Find()
        {
            var solutionContent = File.ReadLines(_solutionFile);
            var projectFiles = new LinkedList<string>();
            foreach (var line in solutionContent)
            {
                if (line.StartsWith("Project"))
                {
                    projectFiles.AddLast(line.Split('=')[1].Split(',')[1]);
                }
            }

            return projectFiles;
        }
    }
}

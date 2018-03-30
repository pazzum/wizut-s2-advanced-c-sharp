using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Zadanie2
{
    class HtmlRandomPicker
    {
        private List<string> htmls = new List<string>();
        private string _path;

        public HtmlRandomPicker(string path)
        {
            _path = path;
            htmls.Add(File.ReadAllText(_path + "table1.html"));
            htmls.Add(File.ReadAllText(_path + "table2.html"));
            htmls.Add(File.ReadAllText(_path + "table3.html"));
            htmls.Add(File.ReadAllText(_path + "table4.html"));
        }

        public string Pick()
        {
            return htmls[new Random().Next(htmls.Count)];
        }
    }
}

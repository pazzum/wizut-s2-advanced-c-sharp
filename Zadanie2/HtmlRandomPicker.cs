using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Zadanie2
{
    class HtmlRandomPicker
    {
        private List<string> htmls = new List<string>();

        public HtmlRandomPicker()
        {
            htmls.Add(File.ReadAllText("table1.html"));
            htmls.Add(File.ReadAllText("table2.html"));
            htmls.Add(File.ReadAllText("table3.html"));
            htmls.Add(File.ReadAllText("table4.html"));
        }

        public string Pick()
        {
            return htmls[new Random().Next(htmls.Count)];
        }
    }
}

using System.Collections.Generic;

namespace Zadanie1.Elements
{
    public class Row : Element, IHtmlable
    {
        private readonly List<Cell> _cells;

        public Row(string content, string attribute = null) : base(content, attribute)
        {
            Html += "<tr>";

            Html += content;

            Html += "</tr>";
        }

        public Row(List<Cell> cells)
        {
            _cells = cells;

            Html = "";

            cells.ForEach(delegate(Cell cell) { Html += cell.GenerateHtml(); });

            Html = BoundTr(Html);
        }

        public string GenerateHtml()
        {
            Html = "";

            _cells.ForEach(delegate(Cell cell) { Html += cell.GenerateHtml(); });

            return BoundTr(Html);
        }

        private static string BoundTr(string content)
        {
            var bounded = "<tr>";

            bounded += content;

            bounded += "</tr>";

            return bounded;
        }
    }
}
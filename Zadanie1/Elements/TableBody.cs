using System.Collections.Generic;

namespace Zadanie1.Elements
{
    public class TableBody : Element, IHtmlable
    {
        public TableBody(List<Row> rows)
        {
            _rows = rows;
        }

        public List<Row> _rows { get; }

        public string GenerateHtml()
        {
            Html = "";

            _rows.ForEach(delegate(Row row) { Html += row.GenerateHtml(); });

            return boundTBody(Html);
        }

        private string boundTBody(string content)
        {
            var html = "<tbody>";

            html += content;

            html += "</tbody>";

            return html;
        }
    }
}
using System.Collections.Generic;

namespace Zadanie1.Elements
{
    public class Header : Element, IHtmlable
    {
        public Header(List<Row> rows)
        {
            _rows = rows;
        }

        public List<Row> _rows { get; }

        public string GenerateHtml()
        {
            Html = "";

            _rows.ForEach(delegate(Row row) { Html += row.GenerateHtml(); });

            return boundTHead(Html);
        }

        private string boundTHead(string content)
        {
            var html = "<thead>";

            html += content;

            html += "</thead>";

            return html;
        }
    }
}
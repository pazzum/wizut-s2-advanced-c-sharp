using System.Collections.Generic;

namespace Zadanie1.Elements
{
    public class Footer : Element, IHtmlable
    {
        public Footer(List<Row> rows)
        {
            _rows = rows;
        }

        public List<Row> _rows { get; }

        public string GenerateHtml()
        {
            Html = "";

            _rows.ForEach(delegate(Row row) { Html += row.GenerateHtml(); });

            return BoundTFoot(Html);
        }

        private static string BoundTFoot(string content)
        {
            var html = "<tfoot>";

            html += content;

            html += "</tfoot>";

            return html;
        }
    }
}
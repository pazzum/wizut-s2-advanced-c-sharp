using System.Collections.Generic;

namespace Zadanie1.Elements
{
    public class Table : Element, IHtmlable
    {
        public Footer _footer;
        public Header _header;
        public TableBody _tableBody;

        public Table()
        {
        }

        public Table(List<Row> tableBodyRows, List<Row> tableHeaderRows = null, List<Row> tableFooterRows = null)
        {
            _tableBody = new TableBody(tableBodyRows);
            _header = new Header(tableHeaderRows);
            _footer = new Footer(tableFooterRows);
        }

        public string GenerateHtml()
        {
            Html = "";

            if (_header != null) Html += _header.GenerateHtml();

            Html += _tableBody.GenerateHtml();

            if (_footer != null) Html += _footer.GenerateHtml();

            return boundTable(Html);
        }

        private string boundTable(string content)
        {
            var html = "<table>";

            html += content;

            html += "</table>";

            return html;
        }
    }
}
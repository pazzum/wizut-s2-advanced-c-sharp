using System;
using System.Collections.Generic;
using System.Linq;
using Zadanie1.Elements;

namespace Zadanie1
{
    public class Generator
    {
        private readonly Table _table;

        public Generator(List<List<Tuple<string, string>>> rows, List<List<Tuple<string, string>>> header = null,
            List<List<Tuple<string, string>>> footer = null)
        {
            _table = new Table();

            if (header != null)
                AddHeader(header);

            _table._tableBody = new TableBody(new List<Row>());

            rows.ForEach(AddRow);

            if (footer != null)
                AddFooter(footer);

            GeneratedHtml += _table.GenerateHtml();

            BoundTable();
        }

        public string GeneratedHtml { get; private set; }

        public void AddRow(List<Tuple<string, string>> list)
        {
            _table._tableBody._rows.Add(new Row(FillTableData(list)));
        }

        private static List<Cell> FillTableData(IEnumerable<Tuple<string, string>> list)
        {
            return list.Select(keyValuePair => new TableData(keyValuePair.Item2, keyValuePair.Item1)).Cast<Cell>()
                .ToList();
        }

        private List<Cell> FillHeadData(IEnumerable<Tuple<string, string>> list)
        {
            return list.Select(keyValuePair => new TableHead(keyValuePair.Item2, keyValuePair.Item1)).Cast<Cell>()
                .ToList();
        }

        public void AddHeader(List<List<Tuple<string, string>>> rowsList)
        {
            _table._header = new Header(new List<Row>());

            rowsList.ForEach(delegate(List<Tuple<string, string>> list)
            {
                _table._header._rows.Add(new Row(FillHeadData(list)));
            });
        }

        public void AddFooter(List<List<Tuple<string, string>>> rowsList)
        {
            _table._footer = new Footer(new List<Row>());

            rowsList.ForEach(delegate(List<Tuple<string, string>> list)
            {
                _table._footer._rows.Add(new Row(FillTableData(list)));
            });
        }

        private void BoundTable()
        {
            const string begginingHtml = "<html>" +
                                         "<head>" +
                                         "</head>" +
                                         "<body>";

            const string endHtml = "</body>" +
                                   "</html>";


            GeneratedHtml = begginingHtml + GeneratedHtml;
            GeneratedHtml += endHtml;
        }
    }
}
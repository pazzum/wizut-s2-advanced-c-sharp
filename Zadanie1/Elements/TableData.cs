namespace Zadanie1.Elements
{
    public class TableData : Cell
    {
        public TableData(string content, string attribute) : base(content, attribute)
        {
            Type = "td";
        }
    }
}
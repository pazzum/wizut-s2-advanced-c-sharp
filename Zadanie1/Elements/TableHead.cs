namespace Zadanie1.Elements
{
    public class TableHead : Cell
    {
        public TableHead(string content, string attribute) : base(content, attribute)
        {
            Type = "th";
        }
    }
}
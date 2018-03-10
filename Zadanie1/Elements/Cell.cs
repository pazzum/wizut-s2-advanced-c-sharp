namespace Zadanie1.Elements
{
    public class Cell : Element, IHtmlable
    {
        private readonly string _attribute;
        private readonly string _content;

        protected Cell(string content, string attribute) : base(content, attribute)
        {
            _content = content;
            _attribute = attribute;
        }

        protected string Type { get; set; }

        public string GenerateHtml()
        {
            Html = "";

            if (_attribute.Length != 0)
                CellStartWithClass();
            else
                CellStartWithoutClass();

            Html += _content;
            Html += "</" + Type + ">";

            return Html;
        }

        private void CellStartWithClass()
        {
            Html += "<" + Type + " class=\"";
            Html += _attribute;
            Html += "\">";
        }

        private void CellStartWithoutClass()
        {
            Html += "<" + Type + ">";
        }
    }
}
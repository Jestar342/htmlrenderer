using System.Globalization;

namespace HtmlRenderer.Form.Tags
{
    public class TextAreaTag : FormBuilderTag, ITextAreaTag
    {
        public TextAreaTag(IHtmlFormBuilder htmlFormBuilder, string name) : base("textarea", htmlFormBuilder)
        {
            Attributes["name"] = name;
            IsSelfClosing = false;
        }

        public ITextAreaTag Columns(int columns)
        {
            Attributes["cols"] = columns.ToString(CultureInfo.InvariantCulture);
            return this;
        }

        public ITextAreaTag Rows(int rows)
        {
            Attributes["rows"] = rows.ToString(CultureInfo.InvariantCulture);
            return this;
        }
    }
}
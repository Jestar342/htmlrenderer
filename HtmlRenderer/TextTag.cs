using System.Xml;

namespace HtmlRenderer
{
    public class TextTag : ITextTag
    {
        private readonly string text;

        public TextTag(string text)
        {
            this.text = text;
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            parent.AppendChild(xmlDocument.CreateTextNode(text));
        }
    }
}
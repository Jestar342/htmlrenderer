using System.Xml;

namespace HtmlRenderer.Tags
{
    public class TextTag : ITag
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
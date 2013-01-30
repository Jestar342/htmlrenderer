using System.Xml;

namespace HtmlRenderer
{
    public class HtmlTag : IHtmlTag
    {
        private readonly IHeadTag headTag;

        public HtmlTag()
        {
            headTag = new HeadTag();
        }

        public void RenderOn(XmlDocument xmlDocument)
        {
            var element = xmlDocument.CreateElement("html");
            headTag.RenderOn(element, xmlDocument);
            xmlDocument.AppendChild(element);
        }
    }
}
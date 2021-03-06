using System.Xml;

namespace HtmlRenderer.Tags
{
    public class HtmlTag : IHtmlTag
    {
        public HtmlTag(IHeadTag headTag, IBodyTag bodyTag)
        {
            Head = headTag;
            Body = bodyTag;
        }

        public HtmlTag()
            : this(new HeadTag(), new BodyTag())
        {
        }

        public IHeadTag Head { get; private set; }
        public IBodyTag Body { get; private set; }

        public void RenderOn(XmlDocument xmlDocument)
        {
            var htmlTag = xmlDocument.CreateElement("html");
            htmlTag.SetAttribute("lang", "en");
            Head.RenderOn(htmlTag, xmlDocument);
            Body.RenderOn(htmlTag, xmlDocument);
            xmlDocument.AppendChild(htmlTag);
        }
    }
}
using System.Xml;

namespace HtmlRenderer
{
    public class LinkTag : ILinkTag
    {
        public string Rel { get; private set; }
        public string Href { get; private set; }

        public LinkTag(string rel, string href)
        {
            Rel = rel;
            Href = href;
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var linkTag = xmlDocument.CreateElement("link");
            linkTag.SetAttribute("rel", Rel);
            linkTag.SetAttribute("href", Href);
            parent.AppendChild(linkTag);
        }
    }
}
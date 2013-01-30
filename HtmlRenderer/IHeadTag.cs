using System.Collections.Generic;
using System.Xml;

namespace HtmlRenderer
{
    public interface ITag
    {
        void RenderOn(XmlElement parent, XmlDocument xmlDocument);
    }

    public interface IHeadTag : ITag
    {
        string Title { get; set; }
        IList<ILinkTag> Links { get; }
        IList<IScriptTag> Scripts { get; }
    }

    public interface IScriptTag : ITag
    {
        string Src { get; }
        string Type { get; }
    }

    public interface ILinkTag : ITag
    {
        string Rel { get; }
        string Href { get; }
    }

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
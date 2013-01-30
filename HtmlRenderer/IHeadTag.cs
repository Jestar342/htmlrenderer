using System.Xml;

namespace HtmlRenderer
{
    public interface IHeadTag
    {
        void RenderOn(XmlElement parent, XmlDocument xmlDocument);
    }
}
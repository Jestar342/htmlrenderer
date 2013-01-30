using System.Xml;

namespace HtmlRenderer
{
    public interface ITag
    {
        void RenderOn(XmlElement parent, XmlDocument xmlDocument);
    }
}
using System.Xml;

namespace HtmlRenderer
{
    public interface IHtmlTag
    {
        void RenderOn(XmlDocument xmlDocument);
    }
}
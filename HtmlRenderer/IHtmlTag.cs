using System.Xml;

namespace HtmlRenderer
{
    public interface IHtmlTag
    {
        void RenderOn(XmlDocument xmlDocument);
        IHeadTag Head { get; }
        IBuildableTag Body { get; }
    }
}
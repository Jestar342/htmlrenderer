using System.Xml;

namespace HtmlRenderer
{
    public class HeadTag : IHeadTag
    {
        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var headElement = xmlDocument.CreateElement("head");
            parent.AppendChild(headElement);
        }
    }
}
using System.Xml;

namespace HtmlRenderer
{
    public class RawMarkup : ITag
    {
        private readonly string rawMarkup;

        public RawMarkup(string rawMarkup)
        {
            this.rawMarkup = rawMarkup;
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            parent.InnerXml += rawMarkup;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HtmlRenderer
{
    public class HeadTag : IHeadTag
    {
        public HeadTag()
        {
            Links = new List<ILinkTag>();
            Scripts = new List<IScriptTag>();
        }
        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var headElement = xmlDocument.CreateElement("head");
            
            if (!string.IsNullOrWhiteSpace(Title))
            {
                var title = xmlDocument.CreateElement("title");
                title.InnerText = Title;
                headElement.AppendChild(title);
            }

            Links.ToList().ForEach(linkTag => linkTag.RenderOn(headElement, xmlDocument));

            Scripts.ToList().ForEach(scriptTag => scriptTag.RenderOn(headElement, xmlDocument));

            parent.AppendChild(headElement);
        }

        public string Title { get; set; }
        public IList<ILinkTag> Links { get; private set; }
        public IList<IScriptTag> Scripts { get; private set; }
    }
}
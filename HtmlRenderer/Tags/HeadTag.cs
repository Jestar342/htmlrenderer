using System;
using System.Collections.Generic;
using System.Xml;

namespace HtmlRenderer.Tags
{
    public class HeadTag : IHeadTag
    {
        private readonly List<ITag> children;

        public HeadTag()
        {
            children = new List<ITag>();
        }

        public void With(Action<IHtmlHeadBuilder> builderAction)
        {
            builderAction(new HtmlHeadBuilder(children));
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var headElement = xmlDocument.CreateElement("head");
            children.ForEach(tag => tag.RenderOn(headElement, xmlDocument));
            parent.AppendChild(headElement);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Xml;

namespace HtmlRenderer
{
    public class BodyTag : IBuildableTag
    {
        private List<ITag> children;

        public BodyTag()
        {
            children = new List<ITag>();
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var bodyTag = xmlDocument.CreateElement("body");
            children.ForEach(child => child.RenderOn(bodyTag, xmlDocument));
            parent.AppendChild(bodyTag);
        }

        public IBuildableTag With(Action<IHtmlBuilder> builderAction)
        {
            var builder = new HtmlBuilder(children);
            builderAction(builder);
            return this;
        }
    }
}
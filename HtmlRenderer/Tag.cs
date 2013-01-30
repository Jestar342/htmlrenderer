using System;
using System.Collections.Generic;
using System.Xml;

namespace HtmlRenderer
{
    public class Tag : IBuildableTag
    {
        private readonly List<ITag> children;
        private readonly string name;

        public Tag(string name)
        {
            this.name = name;
            children = new List<ITag>();
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var tag = xmlDocument.CreateElement(name);
            children.ForEach(child => child.RenderOn(tag, xmlDocument));
            parent.AppendChild(tag);
        }

        public IBuildableTag With(Action<IHtmlBuilder> builderAction)
        {
            builderAction(new HtmlBuilder(children));
            return this;
        }
    }
}
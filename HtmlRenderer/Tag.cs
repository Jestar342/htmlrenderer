using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HtmlRenderer
{
    public class Tag : IBuildableTag
    {
        private readonly List<ITag> children;
        protected IHtmlBuilder HtmlBuilder;
        private readonly string name;

        public Tag(string name, IHtmlBuilder htmlBuilder)
            : this(name)
        {
            HtmlBuilder = htmlBuilder;
        }

        protected Tag(string name)
        {
            this.name = name;
            children = new List<ITag>();
            Attributes = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Attributes { get; protected set; }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var tag = xmlDocument.CreateElement(name);

            Attributes.ToList().ForEach(attribute => tag.SetAttribute(attribute.Key, attribute.Value));

            children.ForEach(child => child.RenderOn(tag, xmlDocument));
            parent.AppendChild(tag);
        }

        public IHtmlBuilder With(Action<IHtmlBuilder> builderAction)
        {
            builderAction(new HtmlBuilder(children));
            return HtmlBuilder;
        }

        public IBuildableTag WithClass(string @class)
        {
            if (Attributes.ContainsKey("class"))
                Attributes["class"] += string.Format(" {0}", @class);
            else
                Attributes["class"] = @class;
            return this;
        }
    }
}
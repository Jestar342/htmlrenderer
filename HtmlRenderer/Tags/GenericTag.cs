using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;

namespace HtmlRenderer.Tags
{
    public class GenericTag : IBuildableTag
    {
        private readonly string name;
        protected readonly List<ITag> Children;
        protected IHtmlBuilder HtmlBuilder;
        protected bool IsSelfClosing = true;

        public GenericTag(string name, IHtmlBuilder htmlBuilder)
            : this(name)
        {
            HtmlBuilder = htmlBuilder;
        }

        protected GenericTag(string name)
        {
            this.name = name;
            Children = new List<ITag>();
            Attributes = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Attributes { get; protected set; }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var tag = xmlDocument.CreateElement(name);
            tag.IsEmpty = IsSelfClosing;
            Attributes.ToList().ForEach(attribute => tag.SetAttribute(attribute.Key, attribute.Value));
            Children.ForEach(child => child.RenderOn(tag, xmlDocument));
            parent.AppendChild(tag);
        }

        public IHtmlBuilder With(Action<IHtmlBuilder> builderAction)
        {
            builderAction(new HtmlBuilder(Children));
            return HtmlBuilder;
        }

        public IBuildableTag Class(string @class)
        {
            if (Attributes.ContainsKey("class"))
                Attributes["class"] += string.Format(" {0}", @class);
            else
                Attributes["class"] = @class;
            return this;
        }

        public IBuildableTag Id(string id)
        {
            Attributes["id"] = id;
            return this;
        }
    }
}
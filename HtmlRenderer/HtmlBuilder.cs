using System.Collections.Generic;

namespace HtmlRenderer
{
    public class HtmlBuilder : IHtmlBuilder
    {
        private readonly List<ITag> tags;

        public HtmlBuilder(List<ITag> tags)
        {
            this.tags = tags;
        }

        public IBuildableTag Div
        {
            get { return CreateChildTag("div"); }
        }

        public IBuildableTag Span
        {
            get { return CreateChildTag("span"); }
        }

        public IBuildableTag Paragraph
        {
            get { return CreateChildTag("p"); }
        }

        public IHtmlBuilder Text(string text)
        {
            tags.Add(new TextTag(text));
            return this;
        }

        public IBuildableTag Anchor(string href)
        {
            var buildableTag = CreateChildTag("a");
            buildableTag.Attributes["href"] = href;
            return buildableTag;
        }

        private IBuildableTag CreateChildTag(string name)
        {
            var tag = new Tag(name, this);
            tags.Add(tag);
            return tag;
        }
    }
}
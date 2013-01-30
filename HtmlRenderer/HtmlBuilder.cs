using System.Collections.Generic;

namespace HtmlRenderer
{
    public class HtmlBuilder : IHtmlBuilder
    {
        private readonly List<ITag> children;

        public HtmlBuilder(List<ITag> children)
        {
            this.children = children;
        }

        public IBuildableTag Div
        {
            get
            {
                var tag = new Tag("div");
                children.Add(tag);
                return tag;
            }
        }

        public IBuildableTag Span
        {
            get
            {
                var tag = new Tag("span");
                children.Add(tag);
                return tag;
            }
        }

        public IBuildableTag Paragraph
        {
            get
            {
                var paragraphTag = new Tag("p");
                children.Add(paragraphTag);
                return paragraphTag;
            }
        }

        public IHtmlBuilder Text(string text)
        {
            children.Add(new TextTag(text));
            return this;
        }
    }
}
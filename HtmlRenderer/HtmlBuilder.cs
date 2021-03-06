using System.Collections.Generic;
using HtmlRenderer.Form;
using HtmlRenderer.Form.Tags;
using HtmlRenderer.Tags;

namespace HtmlRenderer
{
    public class HtmlBuilder : IHtmlBuilder
    {
        protected readonly List<ITag> Tags;

        public HtmlBuilder(List<ITag> tags)
        {
            Tags = tags;
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

        public IBuildableTag UnorderedList
        {
            get { return CreateChildTag("ul"); }
        }

        public IBuildableTag ListItem
        {
            get { return CreateChildTag("li"); }
        }

        public IBuildableTag OrderedList
        {
            get { return CreateChildTag("ol"); }
        }

        public IHtmlBuilder Text(string text)
        {
            Tags.Add(new TextTag(text));
            return this;
        }

        public IBuildableTag Anchor(string href)
        {
            var buildableTag = CreateChildTag("a");
            buildableTag.Attributes["href"] = href;
            return buildableTag;
        }

        public IImageTag Image(string src)
        {
            var imageTag = new ImageTag(src, this);
            Tags.Add(imageTag);
            return imageTag;
        }

        public IFormTag Form(string formAction)
        {
            var formTag = new FormTag(formAction, "post", this);
            Tags.Add(formTag);
            return formTag;
        }

        public IBuildableTag Heading(int headingLevel)
        {
            return CreateChildTag(string.Format("h{0}", headingLevel));
        }

        public IHtmlBuilder RawMarkup(string rawMarkup)
        {
            ITag tag = new RawMarkup(rawMarkup);
            Tags.Add(tag);
            return this;
        }

        public IBuildableTag CreateChildTag(string name)
        {
            var tag = new GenericTag(name, this);
            Tags.Add(tag);
            return tag;
        }
    }
}
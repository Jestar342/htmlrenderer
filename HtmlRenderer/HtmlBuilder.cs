using System.Collections.Generic;

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

        public IBuildableTag CreateChildTag(string name)
        {
            var tag = new Tag(name, this);
            Tags.Add(tag);
            return tag;
        }
    }
}
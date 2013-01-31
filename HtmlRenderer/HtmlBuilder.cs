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

        public IImageTag Image(string src)
        {
            var imageTag = new ImageTag(src, this);
            tags.Add(imageTag);
            return imageTag;
        }

        public IFormTag Form(string formAction)
        {
            var formTag = new FormTag(formAction, "post", this);
            tags.Add(formTag);
            return formTag;
        }

        public IBuildableTag SubmitButton(string buttonText)
        {
            var submitButton = CreateChildTag("input");
            submitButton.Attributes["type"] = "submit";
            submitButton.Attributes["value"] = buttonText;
            return submitButton;
        }

        public IBuildableTag Textbox(string textBoxName)
        {
            var tag = CreateChildTag("input");
            tag.Attributes["type"] = "text";
            tag.Attributes["name"] = textBoxName;
            return tag;
        }

        private IBuildableTag CreateChildTag(string name)
        {
            var tag = new Tag(name, this);
            tags.Add(tag);
            return tag;
        }
    }
}
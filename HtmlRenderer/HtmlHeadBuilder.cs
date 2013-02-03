using System.Collections.Generic;

namespace HtmlRenderer
{
    public class HtmlHeadBuilder : IHtmlHeadBuilder
    {
        private readonly List<ITag> children;

        public HtmlHeadBuilder(List<ITag> tags)
        {
            children = tags;
        }

        public IHtmlHeadBuilder Title(string value)
        {
            var tag = CreateChildTag("title");
            tag.With(builder => builder.Text(value));
            return this;
        }

        public IHtmlHeadBuilder Stylesheet(string href)
        {
            var tag = CreateChildTag("link");
            tag.Attributes["href"] = href;
            tag.Attributes["rel"] = "stylesheet";
            return this;
        }

        public IHtmlHeadBuilder Script(string src)
        {
            var tag = new ScriptTag(src, "text/javascript");
            children.Add(tag);
            return this;
        }

        private Tag CreateChildTag(string title)
        {
            var tag = new Tag(title, null);
            children.Add(tag);
            return tag;
        }
    }
}
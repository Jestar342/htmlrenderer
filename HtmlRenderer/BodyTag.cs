using System.Collections.Generic;

namespace HtmlRenderer
{
    public class BodyTag : Tag, IBodyTag
    {
        private readonly List<ITag> children;

        public BodyTag() : base("body")
        {
            children = new List<ITag>();
            Attributes = new Dictionary<string, string>();
            HtmlBuilder = new HtmlBuilder(children);
        }
    }
}
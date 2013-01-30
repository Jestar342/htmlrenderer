using System;

namespace HtmlRenderer
{
    public interface IBuildableTag : ITag
    {
        IBuildableTag With(Action<IHtmlBuilder> builderAction);
    }
}
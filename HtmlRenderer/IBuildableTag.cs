using System;
using System.Collections.Generic;

namespace HtmlRenderer
{
    public interface IBuildableTag : ITag
    {
        IHtmlBuilder With(Action<IHtmlBuilder> builderAction);
        IDictionary<string, string> Attributes { get; }
        IBuildableTag WithClass(string @class);
    }
}
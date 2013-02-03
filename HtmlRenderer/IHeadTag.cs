using System;

namespace HtmlRenderer
{
    public interface IHeadTag : ITag
    {
        void With(Action<IHtmlHeadBuilder> builderAction);        
    }
}
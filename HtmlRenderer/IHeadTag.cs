using System.Collections.Generic;

namespace HtmlRenderer
{
    public interface IHeadTag : ITag
    {
        string Title { get; set; }
        IList<ILinkTag> Links { get; }
        IList<IScriptTag> Scripts { get; }
    }
}
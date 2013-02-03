using System;
using HtmlRenderer.Form;

namespace HtmlRenderer
{
    public interface IFormBuilderTag
    {
        IHtmlBuilder With(Action<IHtmlFormBuilder> builderAction);
    }
}
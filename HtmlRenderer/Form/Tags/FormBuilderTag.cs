using System;
using HtmlRenderer.Tags;

namespace HtmlRenderer.Form.Tags
{
    public class FormBuilderTag : GenericTag
    {
        public FormBuilderTag(string name, IHtmlBuilder htmlBuilder) : base(name, htmlBuilder)
        {
        }

        public IHtmlBuilder With(Action<IHtmlFormBuilder> builderAction)
        {
            builderAction(new HtmlFormBuilder(Children));
            return HtmlBuilder;
        }
    }
}
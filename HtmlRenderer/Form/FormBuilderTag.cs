using System;

namespace HtmlRenderer.Form
{
    public class FormBuilderTag : Tag
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
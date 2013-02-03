namespace HtmlRenderer.Form
{
    public class FormChildTag : FormBuilderTag
    {
        private readonly IHtmlFormBuilder htmlFormBuilder;

        public FormChildTag(string tagName, IHtmlFormBuilder htmlFormBuilder) : base(tagName, htmlFormBuilder)
        {
            this.htmlFormBuilder = htmlFormBuilder;
        }
    }

    public class FieldsetTag : FormChildTag, IFieldsetTag
    {
        public FieldsetTag(IHtmlFormBuilder htmlFormBuilder) 
            : base("fieldset", htmlFormBuilder)
        {
        }

        public IFieldsetTag Legend(string fieldsetLegend)
        {
            var legendTag = new Tag("legend", null);
            legendTag.With(builder => builder.Text(fieldsetLegend));
            Children.Add(legendTag);
            return this;
        }
    }
}
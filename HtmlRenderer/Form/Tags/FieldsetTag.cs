using HtmlRenderer.Tags;

namespace HtmlRenderer.Form.Tags
{
    public class FieldsetTag : FormBuilderTag, IFieldsetTag
    {
        public FieldsetTag(IHtmlBuilder htmlFormBuilder) 
            : base("fieldset", htmlFormBuilder)
        {
        }

        public IFieldsetTag Legend(string fieldsetLegend)
        {
            var legendTag = new GenericTag("legend", null);
            legendTag.With(builder => builder.Text(fieldsetLegend));
            Children.Add(legendTag);
            return this;
        }
    }
}
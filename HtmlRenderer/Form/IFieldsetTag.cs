namespace HtmlRenderer.Form
{
    public interface IFieldsetTag : IFormBuilderTag
    {
        IFieldsetTag Legend(string fieldsetLegend);
    }
}
namespace HtmlRenderer
{
    public interface IImageTag : IBuildableTag
    {
        IImageTag AlternativeText(string altText);
    }
}
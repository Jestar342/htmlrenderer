namespace HtmlRenderer
{
    public interface IHtmlBuilder
    {
        IBuildableTag Div { get; }
        IBuildableTag Span { get; }
        IBuildableTag Paragraph { get; }
        IHtmlBuilder Text(string text);
    }
}
namespace HtmlRenderer
{
    public interface IHtmlBuilder
    {
        IBuildableTag Div { get; }
        IBuildableTag Span { get; }
        IBuildableTag Paragraph { get; }
        IBuildableTag UnorderedList { get; }
        IBuildableTag ListItem { get; }
        IBuildableTag OrderedList { get; }
        IHtmlBuilder Text(string text);
        IBuildableTag Anchor(string href);
        IImageTag Image(string src);
        IFormTag Form(string formAction);
        IBuildableTag Heading(int headingLevel);
        IHtmlBuilder RawMarkup(string rawMarkup);
    }
}
namespace HtmlRenderer
{
    public interface IHtmlBuilder
    {
        IBuildableTag Div { get; }
        IBuildableTag Span { get; }
        IBuildableTag Paragraph { get; }
        IHtmlBuilder Text(string text);
        IBuildableTag Anchor(string href);
        IImageTag Image(string src);
        IFormTag Form(string formAction);
        IBuildableTag SubmitButton(string buttonText);
        IBuildableTag Textbox(string textBoxName);
    }
}
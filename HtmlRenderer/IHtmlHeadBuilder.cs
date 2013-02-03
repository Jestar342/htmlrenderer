namespace HtmlRenderer
{
    public interface IHtmlHeadBuilder
    {
        IHtmlHeadBuilder Title(string value);
        IHtmlHeadBuilder Stylesheet(string href);
        IHtmlHeadBuilder Script(string src);
    }
}
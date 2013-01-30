namespace HtmlRenderer
{
    public interface ILinkTag : ITag
    {
        string Rel { get; }
        string Href { get; }
    }
}
namespace HtmlRenderer
{
    public interface IScriptTag : ITag
    {
        string Src { get; }
        string Type { get; }
    }
}
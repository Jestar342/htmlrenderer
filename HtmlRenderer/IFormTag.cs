namespace HtmlRenderer
{
    public interface IFormTag : IBuildableTag
    {
        IFormTag Action(string formAction);
        IFormTag Method(string method);
    }
}
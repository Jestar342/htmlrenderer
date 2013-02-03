namespace HtmlRenderer
{
    public interface IFormTag : IBuildableTag, IFormBuilderTag
    {
        IFormTag Action(string formAction);
        IFormTag Method(string method);
    }
}
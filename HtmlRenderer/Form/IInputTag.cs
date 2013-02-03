namespace HtmlRenderer.Form
{
    public interface IInputTag : IBuildableTag
    {
        IInputTag Value(string value);
    }
}
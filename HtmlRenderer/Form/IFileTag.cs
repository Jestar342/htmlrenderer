namespace HtmlRenderer.Form
{
    public interface IFileTag : ITag
    {
        IFileTag FileTypesAccepted(string fileTypesAccepted);
    }
}
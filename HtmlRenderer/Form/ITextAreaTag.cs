namespace HtmlRenderer.Form
{
    public interface ITextAreaTag : ITag
    {
        ITextAreaTag Columns(int columns);
        ITextAreaTag Rows(int rows);
    }
}
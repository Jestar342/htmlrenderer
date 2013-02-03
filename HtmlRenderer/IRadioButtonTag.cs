namespace HtmlRenderer
{
    public interface IRadioButtonTag : IBuildableTag
    {
        IRadioButtonTag Checked();
        IRadioButtonTag Value(string value);
    }
}
namespace HtmlRenderer.Form
{
    public interface IHtmlFormBuilder : IHtmlBuilder
    {
        IBuildableTag SubmitButton(string buttonText);
        IInputTag Textbox(string textBoxName);
        IRadioButtonTag RadioButton(string name);
        IFieldsetTag Fieldset { get; }
        IHtmlFormBuilder Label(string @for, string text);
    }
}
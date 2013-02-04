namespace HtmlRenderer.Form
{
    public interface IHtmlFormBuilder : IHtmlBuilder
    {
        IBuildableTag SubmitButton(string buttonText);
        IInputTag Textbox(string textBoxName);
        IRadioButtonTag RadioButton(string name);
        IFieldsetTag Fieldset { get; }
        IBuildableTag Label(string @for);
        ITextAreaTag TextArea(string textareaName);
        IInputTag PasswordTextBox(string passwordName);
        IBuildableTag ResetButton(string buttonText);
    }
}
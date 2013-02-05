using System.Collections.Generic;

namespace HtmlRenderer.Form
{
    public class HtmlFormBuilder : HtmlBuilder, IHtmlFormBuilder
    {
        public HtmlFormBuilder(List<ITag> childTags) 
            : base(childTags)
        {
        }

        public IFieldsetTag Fieldset
        {
            get
            {
                var fieldsetTag = new FieldsetTag(this);
                Tags.Add(fieldsetTag);
                return fieldsetTag;
            }
        }

        public IBuildableTag Label(string @for)
        {
            var labelTag = CreateChildTag("label");
            labelTag.Attributes["for"] = @for;
            return labelTag;
        }

        public ITextAreaTag TextArea(string textareaName)
        {
            ITextAreaTag textAreaTag = new TextAreaTag(this, textareaName);
            Tags.Add(textAreaTag);
            return textAreaTag;
        }

        public IBuildableTag SubmitButton(string buttonText)
        {
            var submitButton = CreateChildTag("button");
            submitButton.Attributes["type"] = "submit";
            submitButton.With(builder => builder.Text(buttonText));
            return submitButton;
        }

        public IInputTag Textbox(string textBoxName)
        {
            var tag = new InputTag("text", textBoxName);
            Tags.Add(tag);
            return tag;
        }

        public IRadioButtonTag RadioButton(string name)
        {
            var radioTag = new RadioButtonTag(name, this);
            Tags.Add(radioTag);
            return radioTag;
        }

        public IInputTag PasswordTextBox(string passwordName)
        {
            var passwordTag = new InputTag("password", passwordName);
            Tags.Add(passwordTag);
            return passwordTag;
        }

        public IBuildableTag ResetButton(string buttonText)
        {
            var tag = CreateChildTag("button");
            tag.Attributes["type"] = "reset";
            tag.With(builder => builder.Text(buttonText));
            return tag;
        }

        public IFileTag File(string name)
        {
            var fileTag = new FileTag(name);
            Tags.Add(fileTag);
            return fileTag;
        }
    }
}
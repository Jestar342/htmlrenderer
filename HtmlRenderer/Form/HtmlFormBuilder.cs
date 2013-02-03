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

        public IHtmlFormBuilder Label(string @for, string text)
        {
            var labelTag = CreateChildTag("label");
            labelTag.Attributes["for"] = @for;
            labelTag.With(builder => builder.Text(text));
            return this;
        }

        public IBuildableTag SubmitButton(string buttonText)
        {
            var submitButton = CreateChildTag("input");
            submitButton.Attributes["type"] = "submit";
            submitButton.Attributes["value"] = buttonText;
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
    }
}
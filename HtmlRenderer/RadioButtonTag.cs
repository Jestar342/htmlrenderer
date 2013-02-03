namespace HtmlRenderer
{
    public class RadioButtonTag : Tag, IRadioButtonTag
    {
        public RadioButtonTag(string name, IHtmlBuilder htmlBuilder) : base("radio", htmlBuilder)
        {
            Attributes["name"] = name;
        }

        public IRadioButtonTag Checked()
        {
            Attributes["checked"] = "checked";
            return this;
        }
    }
}
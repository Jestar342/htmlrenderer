namespace HtmlRenderer
{
    public class RadioButtonTag : GenericTag, IRadioButtonTag
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

        public IRadioButtonTag Value(string value)
        {
            Attributes["value"] = value;
            return this;
        }
    }
}
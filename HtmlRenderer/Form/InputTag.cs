namespace HtmlRenderer.Form
{
    public class InputTag : Tag, IInputTag
    {
        public InputTag(string type, string name) 
            : base("input")
        {
            Attributes["type"] = type;
            Attributes["name"] = name;
        }

        public IInputTag Value(string value)
        {
            Attributes["value"] = value;
            return this;
        }
    }
}
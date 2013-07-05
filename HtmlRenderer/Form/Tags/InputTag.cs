using HtmlRenderer.Tags;

namespace HtmlRenderer.Form.Tags
{
    public class InputTag : GenericTag, IInputTag
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
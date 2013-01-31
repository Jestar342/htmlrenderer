using System.Xml;

namespace HtmlRenderer
{
    public class ScriptTag : IScriptTag
    {
        public string Src { get; private set; }
        public string Type { get; private set; }

        public ScriptTag(string src, string type)
        {
            Src = src;
            Type = type;
        }

        public void RenderOn(XmlElement parent, XmlDocument xmlDocument)
        {
            var scriptTag = xmlDocument.CreateElement("script");
            scriptTag.SetAttribute("src", Src);
            scriptTag.SetAttribute("type", Type);
            scriptTag.IsEmpty = false;
            parent.AppendChild(scriptTag);
        }
    }
}
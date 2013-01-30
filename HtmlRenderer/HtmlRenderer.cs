using System.IO;
using System.Xml;

namespace HtmlRenderer
{
    public class HtmlRenderer
    {
        private IHtmlTag htmlTag;

        public HtmlRenderer(Stream stream)
        {
            Stream = stream;
            htmlTag = new HtmlTag();
        }

        public Stream Stream { get; private set; }

        public void Render()
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.AppendChild(xmlDocument.CreateDocumentType("html", null, null, null));
            htmlTag.RenderOn(xmlDocument);
            xmlDocument.Save(Stream);
        }
    }
}
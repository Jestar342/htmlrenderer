using System.IO;
using System.Xml;

namespace HtmlRenderer
{
    public class HtmlRenderer
    {
        private readonly IHtmlTag htmlTag;

        public HtmlRenderer(Stream stream)
        {
            Stream = stream;
            htmlTag = new HtmlTag();
        }

        public Stream Stream { get; private set; }

        public IHeadTag Head
        {
            get { return htmlTag.Head; }
        }

        public IBuildableTag Body
        {
            get { return htmlTag.Body; }
        }

        public void Render()
        {
            var xmlDocument = new XmlDocument();
            var xmlDocumentType = xmlDocument.CreateDocumentType("html", null, null, null);
            xmlDocument.AppendChild(xmlDocumentType);
            htmlTag.RenderOn(xmlDocument);
            xmlDocument.Save(Stream);
        }
    }
}
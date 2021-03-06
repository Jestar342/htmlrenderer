﻿using System.IO;
using System.Xml;
using HtmlRenderer.Tags;

namespace HtmlRenderer
{
    public class HtmlRenderer
    {
        private readonly TextWriter textWriter;
        private readonly IHtmlTag htmlTag;

        public HtmlRenderer(TextWriter textWriter)
        {
            this.textWriter = textWriter;
            htmlTag = new HtmlTag();
        }

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
            xmlDocument.AppendChild(xmlDocument.CreateDocumentType("html", null, null, null));
            htmlTag.RenderOn(xmlDocument);
            xmlDocument.Save(XmlWriter.Create(textWriter, new XmlWriterSettings { OmitXmlDeclaration = true }));
        }
    }
}
using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHeadElement
    {
        private HtmlHeadBuilder headBuilder;
        private List<ITag> tags;

        [Test]
        public void ShouldRenderScript()
        {
            headBuilder.Script("/src/foo.js");
            Assert.That(GetOutput(), Is.EqualTo(@"<script src=""/src/foo.js"" type=""text/javascript""></script>"));
        }

        [Test]
        public void ShouldRenderLink()
        {
            headBuilder.Stylesheet("/src/foo.css");
            Assert.That(GetOutput(), Is.EqualTo(@"<link href=""/src/foo.css"" rel=""stylesheet"" />"));
        }

        [Test]
        public void ShouldRenderTitle()
        {
            headBuilder.Title("foo");
            Assert.That(GetOutput(), Is.EqualTo(@"<title>foo</title>"));
        }

        [SetUp]
        public void InstantiateHeadTag()
        {
            tags = new List<ITag>();
            headBuilder = new HtmlHeadBuilder(tags);
        }

        private string GetOutput()
        {
            var xmlDocument = new XmlDocument();
            var xmlElement = xmlDocument.CreateElement("root");
            tags.ForEach(tag => tag.RenderOn(xmlElement, xmlDocument));
            return xmlElement.InnerXml;
        }
    }
}
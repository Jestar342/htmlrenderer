using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlElements
    {
        [Test]
        public void ShouldRenderSpan()
        {
            htmlBuilder.Span.Class("span-class").With(builder => builder.Text("foo"));
            Assert.That(GetOutput(), Is.EqualTo(@"<span class=""span-class"">foo</span>"));
        }

        [Test]
        public void ShouldRenderParagraph()
        {
            htmlBuilder.Paragraph.With(builder => builder.Text("lolol"));
            Assert.That(GetOutput(), Is.EqualTo(@"<p>lolol</p>"));
        }

        [Test]
        public void ShouldRenderImage()
        {
            htmlBuilder.Image("/src/image.jpg").AlternativeText("alt text");
            Assert.That(GetOutput(), Is.EqualTo(@"<img src=""/src/image.jpg"" alt=""alt text"" />"));
        }

        [Test]
        public void ShouldRenderDiv()
        {
            htmlBuilder.Div.With(builder => builder.Text("foo"));
            Assert.That(GetOutput(), Is.EqualTo(@"<div>foo</div>"));
        }

        [Test]
        public void ShouldRenderForm()
        {
            htmlBuilder.Form("/form/action");
            Assert.That(GetOutput(), Is.EqualTo(@"<form action=""/form/action"" method=""post""></form>"));
        }

        [Test]
        public void ShouldRenderAnchor()
        {
            htmlBuilder.Anchor("/some/link").With(builder => builder.Text("linky text"));
            Assert.That(GetOutput(), Is.StringMatching(@"<a href=""/some/link"">linky text</a>"));
        }

        [Test]
        public void ShouldRenderHeader()
        {
            htmlBuilder.Heading(1).With(builder => builder.Text("Heading"));
            Assert.That(GetOutput(), Is.StringContaining(@"<h1>Heading</h1>"));
        }

        [SetUp]
        public void SetUpBuilder()
        {
            tags = new List<ITag>();
            htmlBuilder = new HtmlBuilder(tags);
        }

        private HtmlBuilder htmlBuilder;
        private List<ITag> tags;

        private string GetOutput()
        {
            var xmlDocument = new XmlDocument();
            var xmlElement = xmlDocument.CreateElement("root");
            tags.ForEach(tag => tag.RenderOn(xmlElement, xmlDocument));
            return xmlElement.InnerXml;
        }
    }
}
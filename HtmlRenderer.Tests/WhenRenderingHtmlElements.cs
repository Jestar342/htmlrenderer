using System.Collections.Generic;
using System.Xml;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlElements
    {
        [Test]
        public void ShouldEscapeText()
        {
            htmlBuilder.Text(@"<a href=""naughty href"">don't click this</a>");
            Assert.That(GetOutput(), Is.EqualTo(@"&lt;a href=""naughty href""&gt;don't click this&lt;/a&gt;"));
        }

        [Test]
        public void ShouldNotEscapeRaw()
        {
            htmlBuilder.RawMarkup(@"<a href=""link"">click</a>");
            Assert.That(GetOutput(), Is.EqualTo(@"<a href=""link"">click</a>"));
        }

        [Test]
        public void ShouldRenderAnchor()
        {
            htmlBuilder.Anchor("/some/link").With(builder => builder.Text("linky text"));
            Assert.That(GetOutput(), Is.EqualTo(@"<a href=""/some/link"">linky text</a>"));
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
        public void ShouldRenderHeader()
        {
            htmlBuilder.Heading(1).With(builder => builder.Text("Heading"));
            Assert.That(GetOutput(), Is.EqualTo(@"<h1>Heading</h1>"));
        }

        [Test]
        public void ShouldRenderImage()
        {
            htmlBuilder.Image("/src/image.jpg").AlternativeText("alt text");
            Assert.That(GetOutput(), Is.EqualTo(@"<img src=""/src/image.jpg"" alt=""alt text"" />"));
        }

        [Test]
        public void ShouldRenderParagraph()
        {
            htmlBuilder.Paragraph.With(builder => builder.Text("lolol"));
            Assert.That(GetOutput(), Is.EqualTo(@"<p>lolol</p>"));
        }

        [Test]
        public void ShouldRenderSpan()
        {
            htmlBuilder.Span.Class("span-class").With(builder => builder.Text("foo"));
            Assert.That(GetOutput(), Is.EqualTo(@"<span class=""span-class"">foo</span>"));
        }

        [Test]
        public void ShouldRenderUnorderedList()
        {
            htmlBuilder.UnorderedList.With(builder =>
                {
                    builder.ListItem.With(builder1 => builder1.Text("first"));
                    builder.ListItem.With(builder1 => builder1.Text("second"));
                });
   
            Assert.That(GetOutput(), Is.EqualTo(@"<ul><li>first</li><li>second</li></ul>"));
        }

        [Test]
        public void ShouldRenderOrderedList()
        {
            htmlBuilder.OrderedList.With(builder => builder.ListItem.With(builder1 => builder1.Text("foo")));
            Assert.That(GetOutput(), Is.EqualTo("<ol><li>foo</li></ol>"));
        }

        [SetUp]
        public void SetUpBuilder()
        {
            tags = new List<ITag>();
            htmlBuilder = new HtmlBuilder(tags);
        }

        private IHtmlBuilder htmlBuilder;
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
using System.IO;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlDocuments
    {
        [Test]
        public void NotARealTestIJustWantToSeeTheOutput()
        {
            Assert.Fail(output);
        }

        [Test]
        public void ShouldRenderAnchor()
        {
            Assert.That(output, Is.StringMatching(@"<a(?=.*href=""/some/link"")(?=.*class=""anchor-class"").*>(.*|\s*)</a>"));
        }

        [Test]
        public void ShouldRenderBody()
        {
            Assert.That(output, Is.StringMatching(@"<body class=""body-class"">(.*|\s*)</body>"));
        }

        [Test]
        public void ShouldRenderDiv()
        {
            Assert.That(output, Is.StringMatching(@"<div id=""div-id"">(.*|\s*)</div>"));
        }

        [Test]
        public void ShouldRenderDocType()
        {
            Assert.That(output, Is.StringMatching(@"^<!DOCTYPE html\s*>"));
        }

        [Test]
        public void ShouldRenderForm()
        {
            Assert.That(output, Is.StringMatching(@"<form(?=.*action=""/form/action"")(?=.*method=""post"").*>(.*|\s*)</form>"));
        }

        [Test]
        public void ShouldRenderHtmlTag()
        {
            Assert.That(output, Is.StringMatching(@"<html lang=""en"">(.*|\s*)</html>"));
        }

        [Test]
        public void ShouldRenderImage()
        {
            Assert.That(output, Is.StringMatching(@"<img(?=.*src=""/src/image.jpg"")(?=.*alt=""alt text"").*/>"));
        }

        [Test]
        public void ShouldRenderLink()
        {
            Assert.That(output, Is.StringMatching(@"<link(?=.*rel=""stylesheet"")(?=.*href=""/src/foo.css"").*/>"));
        }

        [Test]
        public void ShouldRenderParagraph()
        {
            Assert.That(output, Is.StringMatching(@"<p>(.*|\s*)</p>"));
        }

        [Test]
        public void ShouldRenderRadiobutton()
        {
            Assert.That(output, Is.StringMatching(@"<radio(?=.*name=""radio1"").*/>"));
        }

        [Test]
        public void ShouldRenderScript()
        {
            Assert.That(output, Is.StringMatching(@"<script(?=.*src=""/src/foo.js"")(?=.*type=""text/javascript"").*>(.*|\s*)</script>"));
        }

        [Test]
        public void ShouldRenderSpan()
        {
            Assert.That(output, Is.StringMatching(@"<span class=""span-class"">(.*|\s*)</span>"));
        }

        [Test]
        public void ShouldRenderTitle()
        {
            Assert.That(output, Is.StringContaining(@"<title>foo</title>"));
        }

        [Test]
        public void ShouldRenderHeader()
        {
            Assert.That(output, Is.StringContaining(@"<h1>Heading</h1>"));
        }

        [TestFixtureSetUp]
        public void SetupRendererAndRender()
        {
            using (var stringWriter = new StringWriter())
            {
                var renderer = new HtmlRenderer(stringWriter);

                SetupHeadTag(renderer.Head);

                SetupBodyTag(renderer.Body);

                renderer.Render();

                output = stringWriter.ToString();
            }
        }

        private static void SetupBodyTag(IBuildableTag bodyTag)
        {
            bodyTag
                .Class("body-class")
                .With(htmlBuilder => htmlBuilder
                                         .Heading(1)
                                         .With(builder => builder.Text("Heading"))
                                         .Div.Id("div-id")
                                         .With(builder => builder
                                                              .Text("first text")
                                                              .Span.Class("span-class").With(builder1 => builder1.Text("span content"))
                                                              .Text("second text")
                                                              .Anchor("/some/link").Class("anchor-class").With(builder1 => builder1.Text("clickety-click"))
                                                              .Paragraph.With(builder1 => builder1.Text("paragraph text")))
                                         .Image("/src/image.jpg").AlternativeText("alt text").With(builder => { })
                                         .Form("/form/action").Method("post").With(builder =>
                                             {
                                                 builder.Textbox("text-box");
                                                 builder.RadioButton("radio1").Checked();
                                                 builder.SubmitButton("click to submit");
                                             }));
        }

        private static void SetupHeadTag(IHeadTag headTag)
        {
            headTag.With(builder => builder
                                        .Title("foo")
                                        .Stylesheet("/src/foo.css")
                                        .Script("/src/foo.js"));
        }

        private string output;
    }
}
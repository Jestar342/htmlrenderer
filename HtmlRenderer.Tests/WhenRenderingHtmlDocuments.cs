using System.IO;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlDocuments
    {
        [Test]
        [Ignore]
        public void NotARealTestIJustWantToSeeTheOutput()
        {
            Assert.Fail(output);
        }

        [Test]
        public void ShouldRenderBody()
        {
            Assert.That(output, Is.StringMatching(@"<body class=""body-class"">(.*|\s*)*</body>"));
        }

        [Test]
        public void ShouldRenderDiv()
        {
            Assert.That(output, Is.StringMatching(@"<div>(.*|\s*)</div>"));
        }

        [Test]
        public void ShouldRenderDocType()
        {
            Assert.That(output, Is.StringStarting("<!DOCTYPE html>"));
        }

        [Test]
        public void ShouldRenderHtmlTag()
        {
            Assert.That(output, Is.StringMatching(@"<html lang=""en"">(.*|\s*)*</html>"));
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
        public void ShouldRenderScript()
        {
            Assert.That(output, Is.StringMatching(@"<script(?=.*src=""/src/foo.js"")(?=.*type=""text/javascript"").*/>"));
        }

        [Test]
        public void ShouldRenderSpan()
        {
            Assert.That(output, Is.StringMatching(@"<span class=""span-class"">(.*|\s*)</span>"));
        }

        [Test]
        public void ShouldRenderTitle()
        {
            Assert.That(output, Is.StringContaining("<title>foo</title>"));
        }

        [Test]
        public void ShouldRenderAnchor()
        {
            Assert.That(output, Is.StringMatching(@"<a(?=.*href=""/some/link"")(?=.*class=""anchor-class"").*>(.*|\s*)</a>"));
        }

        [Test]
        public void ShouldRenderImage()
        {
            Assert.That(output, Is.StringMatching(@"<img(?=.*src=""/src/image.jpg"")(?=.*alt=""alt text"").*/>"));
        }

        [Test]
        public void ShouldRenderForm()
        {
            Assert.That(output, Is.StringMatching(@"<form(?=.*action=""/form/action"")(?=.*method=""post"").*>(.*|\s)*</form>"));
        }

        [TestFixtureSetUp]
        public void SetupRendererAndRender()
        {
            using (var memoryStream = new MemoryStream())
            {
                var renderer = new HtmlRenderer(memoryStream);

                SetupHeadTag(renderer.Head);

                SetupBodyTag(renderer.Body);

                renderer.Render();
                memoryStream.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(memoryStream);
                output = reader.ReadToEnd();
            }
        }

        private static void SetupBodyTag(IBuildableTag bodyTag)
        {
            bodyTag
                .WithClass("body-class")
                .With(htmlBuilder =>
                          {
                              htmlBuilder
                                  .Div.With(builder => builder
                                                           .Text("first text")
                                                           .Span.WithClass("span-class").With(builder1 => builder1.Text("span content"))
                                                           .Text("second text")
                                                           .Anchor("/some/link").WithClass("anchor-class").With(builder1 => builder1.Text("clickety-click"))
                                                           .Paragraph.With(builder1 => builder1.Text("paragraph text")))
                                  .Image("/src/image.jpg").AlternativeText("alt text").With(builder => { });
                              htmlBuilder.Form("/form/action").Method("post").With(builder => builder.SubmitButton("click to submit"));
                          });
        }

        private static void SetupHeadTag(IHeadTag headTag)
        {
            headTag.Title = "foo";
            headTag.Links.Add(new LinkTag("stylesheet", "/src/foo.css"));
            headTag.Scripts.Add(new ScriptTag("/src/foo.js", "text/javascript"));
        }

        private string output;
    }
}
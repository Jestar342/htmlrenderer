using System.IO;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlDocument
    {
        [Test]
        public void ShouldRenderBody()
        {
            Assert.That(output, Is.StringContaining(@"<body></body>"));
        }

        [Test]
        public void ShouldRenderDocType()
        {
            Assert.That(output, Is.StringStarting(@"<!DOCTYPE html >"));
        }

        [Test]
        public void ShouldRenderHtmlTag()
        {
            Assert.That(output, Is.StringMatching(@"<html lang=""en"">(.*|\s*)</html>"));
        }

        [TestFixtureSetUp]
        public void SetupRendererAndRender()
        {
            var stringWriter = new StringWriter();
            var htmlRenderer = new HtmlRenderer(stringWriter);
            htmlRenderer.Render();
            output = stringWriter.ToString();
        }

        private string output;
    }
}
using System.IO;
using System.Text.RegularExpressions;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlDocuments
    {
        [Test]
        public void ShouldRenderDocType()
        {
            Assert.That(output, Is.StringStarting("<!DOCTYPE html>"));
        }

        [Test]
        public void ShouldRenderHtmlTag()
        {
            Assert.That(output, Is.StringMatching(@"<html>(.*|\s*)*</html>"));
        }

        [Test]
        public void ShouldRenderTitle()
        {
            Assert.That(output, Is.StringMatching("<title>foo</title>"));
        }

        [TestFixtureSetUp]
        public void SetupRendererAndRender()
        {
            using (var memoryStream = new MemoryStream())
            {
                var renderer = new HtmlRenderer(memoryStream);
                renderer.Render();
                memoryStream.Seek(0, SeekOrigin.Begin);
                var reader = new StreamReader(memoryStream);
                output = reader.ReadToEnd();
            }
        }

        private string output;
    }
}
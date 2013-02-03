using System;
using System.IO;
using HtmlRenderer.Form;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlFormElements
    {
        [Test]
        public void ShouldAddFieldsetTagWithLegend()
        {
            Assert.That(output, Is.StringMatching(@"<fieldset>(?=.*<legend>fieldset legend</legend>).*</fieldset>"));
        }

        [Test]
        public void ShouldAddTextbox()
        {
            Assert.That(output, Is.StringMatching(@"<input(?=.*type=""text"")(?=.*value=""textbox value"").*/>"));
        }

        [Test]
        public void ShouldAddSubmitButton()
        {
            Assert.That(output, Is.StringMatching(@"<input(?=.*type=""submit"")(?=.*value=""submit button value"").*/>"));
        }

        [TestFixtureSetUp]
        public void InstantiateRendererAndBuildForm()
        {
            var stringWriter = new StringWriter();
            var renderer = new HtmlRenderer(stringWriter);
            renderer.Body.With(builder => builder.Form("/form/action")
                                                 .With(BuildForm));
            renderer.Render();
            output = stringWriter.ToString();
            Console.Out.WriteLine(output);
        }

        private static void BuildForm(IHtmlFormBuilder formBuilder)
        {
            formBuilder
                .Fieldset
                .Legend("fieldset legend")
                .With(htmlBuilder =>
                    {
                        htmlBuilder
                            .Label("textbox-id", "Label text")
                            .Textbox("textbox-name")
                            .Value("textbox value")
                            .Id("textbox-id");
                        htmlBuilder.SubmitButton("submit button value");
                    });
        }

        private string output;
    }
}
using System.Collections.Generic;
using System.Xml;
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
            formBuilder.Fieldset.Legend("fieldset legend");
            Assert.That(GetOutput(), Is.EqualTo(@"<fieldset><legend>fieldset legend</legend></fieldset>"));
        }

        [Test]
        public void ShouldAddTextbox()
        {
            formBuilder.Textbox("textbox-name").Value("textbox value");
            Assert.That(GetOutput(), Is.EqualTo(@"<input type=""text"" name=""textbox-name"" value=""textbox value"" />"));
        }

        [Test]
        public void ShouldAddSubmitButton()
        {
            formBuilder.SubmitButton("submit button value");
            Assert.That(GetOutput(), Is.EqualTo(@"<input type=""submit"" value=""submit button value"" />"));
        }

        [Test]
        public void ShouldRenderTextarea()
        {
            formBuilder.TextArea("textarea-name").Columns(20).Rows(10);
            Assert.That(GetOutput(), Is.EqualTo(@"<textarea name=""textarea-name"" cols=""20"" rows=""10""></textarea>"));
        }

        [Test]
        public void ShouldRenderRadiobutton()
        {
            formBuilder.RadioButton("radio1").Value("radio-value");
            Assert.That(GetOutput(), Is.EqualTo(@"<radio name=""radio1"" value=""radio-value"" />"));
        }

        [SetUp]
        public void SetUpFormBuilder()
        {
            tags = new List<ITag>();
            formBuilder = new HtmlFormBuilder(tags);
        }

        private string GetOutput()
        {
            var xmlDocument = new XmlDocument();
            var xmlElement = xmlDocument.CreateElement("root");
            xmlDocument.AppendChild(xmlElement);
            tags.ForEach(tag => tag.RenderOn(xmlElement, xmlDocument));
            return xmlElement.InnerXml;
        }

        private HtmlFormBuilder formBuilder;
        private List<ITag> tags;
    }
}
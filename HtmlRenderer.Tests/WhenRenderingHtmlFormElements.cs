﻿using System.Collections.Generic;
using System.Xml;
using HtmlRenderer.Form;
using NUnit.Framework;

namespace HtmlRenderer.Tests
{
    [TestFixture]
    public class WhenRenderingHtmlFormElements
    {
        [Test]
        public void ShouldRenderFileUpload()
        {
            formBuilder.File("file1").FileTypesAccepted("application/foo");
            Assert.That(GetOutput(), Is.EqualTo(@"<input type=""file"" name=""file1"" accept=""application/foo"" />"));
        }
        [Test]
        public void ShouldRenderLabel()
        {
            formBuilder.Label("some-id").With(builder => builder.Text("label text"));
            Assert.That(GetOutput(), Is.EqualTo(@"<label for=""some-id"">label text</label>"));
        }

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
            Assert.That(GetOutput(), Is.EqualTo(@"<button type=""submit"">submit button value</button>"));
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

        [Test]
        public void ShouldRenderPassword()
        {
            formBuilder.PasswordTextBox("password-name").Value("password");
            Assert.That(GetOutput(), Is.EqualTo(@"<input type=""password"" name=""password-name"" value=""password"" />"));
        }

        [Test]
        public void ShouldRenderResetButton()
        {
            formBuilder.ResetButton("Click to reset");
            Assert.That(GetOutput(), Is.EqualTo(@"<button type=""reset"">Click to reset</button>"));
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

        private IHtmlFormBuilder formBuilder;
        private List<ITag> tags;
    }
}
# HtmlRenderer

A Fluid HTML generation tool.

## Example:

A simple example, in a (custom) MVC4 IView.

	using System.IO;
	using System.Web.Mvc;
	using HtmlRenderer;

	namespace MvcApplication1
	{
	    public class MyView : IView
	    {
	        public void Render(ViewContext viewContext, TextWriter writer)
	        {
	            var renderer = new HtmlRenderer.HtmlRenderer(writer);
	            renderer.Head.Title = "foo";
	            renderer.Head.Links.Add(new LinkTag("/src/foo.css", "stylesheet"));
	            renderer.Head.Scripts.Add(new ScriptTag("/src/foo.js", "text/javascript"));

	            renderer.Body
	                .WithClass("body-class")
	                .With(htmlBuilder => htmlBuilder
	                                         .Div.With(builder => builder
	                                                                  .Text("first text")
	                                                                  .Span.WithClass("span-class").With(builder1 => builder1.Text("span content"))
	                                                                  .Text("second text")
	                                                                  .Anchor("/some/link").WithClass("anchor-class").With(builder1 => builder1.Text("clickety-click"))
	                                                                  .Paragraph.With(builder1 => builder1.Text("paragraph text")))
	                                         .Image("/src/image.jpg").AlternativeText("alt text").With(builder => { })
	                                         .Form("/form/action").Method("post").With(builder => builder
	                                                                                                  .Textbox("text-box").With(builder1 => { })
	                                                                                                  .SubmitButton("click to submit")));
	        }
	    }
	}

Will generate the following: HTML markup (indentation has been added to this readme to simply reading)
	
	&lt;!DOCTYPE html &gt;
	&lt;html lang="en"&gt;
	  &lt;head&gt;
	    &lt;title&gt;foo&lt;/title&gt;
	    &lt;link rel="stylesheet" href="/src/foo.css" /&gt;
	    &lt;script src="/src/foo.js" type="text/javascript"&gt;&lt;/script&gt;
	  &lt;/head&gt;
	  &lt;body class="body-class"&gt;
	    &lt;div&gt;first text&lt;span class="span-class"&gt;span content&lt;/span&gt;second text&lt;a href="/some/link" class="anchor-class"&gt;clickety-click&lt;/a&gt;&lt;p&gt;paragraph text&lt;/p&gt;&lt;/div&gt;
	    &lt;img src="/src/image.jpg" alt="alt text" /&gt;
	    &lt;form action="/form/action" method="post"&gt;
	      &lt;input type="text" name="text-box" /&gt;
	      &lt;input type="submit" value="click to submit" /&gt;
	    &lt;/form&gt;
	  &lt;/body&gt;
	&lt;/html&gt;
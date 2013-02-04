# HtmlRenderer

A Fluid HTML generation tool.

## Example:

A simple example, in a (custom) MVC4 IView.

```
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
```

Will generate the following: HTML markup (indentation has been added to this readme to simplify reading)
	
	<!DOCTYPE html >
	<html lang="en">
	  <head>
	    <title>foo</title>
	    <link rel="stylesheet" href="/src/foo.css" />
	    <script src="/src/foo.js" type="text/javascript"></script>
	  </head>
	  <body class="body-class">
	    <div>first text<span class="span-class">span content</span>second text<a href="/some/link" class="anchor-class">clickety-click</a><p>paragraph text</p></div>
	    <img src="/src/image.jpg" alt="alt text" />
	    <form action="/form/action" method="post">
	      <input type="text" name="text-box" />
	      <input type="submit" value="click to submit" />
	    </form>
	  </body>
	</html>
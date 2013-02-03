namespace HtmlRenderer.Form
{
    public class FormTag : FormBuilderTag, IFormTag
    {
        public FormTag(string formAction, string method, IHtmlBuilder htmlBuilder) : base("form", htmlBuilder)
        {
            Action(formAction);
            Method(method);
            IsSelfClosing = false;
        }

        public IFormTag Action(string formAction)
        {
            Attributes["action"] = formAction;
            return this;
        }

        public IFormTag Method(string method)
        {
            Attributes["method"] = method;
            return this;
        }
    }
}
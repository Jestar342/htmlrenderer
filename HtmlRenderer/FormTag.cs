namespace HtmlRenderer
{
    public class FormTag : Tag, IFormTag
    {
        public FormTag(string formAction, string method, IHtmlBuilder htmlBuilder) : base("form", htmlBuilder)
        {
            Action(formAction);
            Method(method);
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
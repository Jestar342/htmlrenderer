namespace HtmlRenderer
{
    public class BodyTag : Tag, IBodyTag
    {
        public BodyTag() : base("body")
        {
            HtmlBuilder = new HtmlBuilder(Children);
            IsSelfClosing = false;
        }
    }
}
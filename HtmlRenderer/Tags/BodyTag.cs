namespace HtmlRenderer.Tags
{
    public class BodyTag : GenericTag, IBodyTag
    {
        public BodyTag() : base("body")
        {
            HtmlBuilder = new HtmlBuilder(Children);
            IsSelfClosing = false;
        }
    }
}
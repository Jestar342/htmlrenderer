namespace HtmlRenderer
{
    public class ImageTag : GenericTag, IImageTag
    {
        public string Src { get; private set; }

        public ImageTag(string src, IHtmlBuilder htmlBuilder) : base("img", htmlBuilder)
        {
            Attributes["src"] = src;
        }

        public IImageTag AlternativeText(string altText)
        {
            Attributes["alt"] = altText;
            return this;
        }
    }
}
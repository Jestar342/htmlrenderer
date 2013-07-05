namespace HtmlRenderer.Form.Tags
{
    public class FileTag : FormBuilderTag, IFileTag
    {
        public FileTag(string name) : base("input", null)
        {
            Attributes["type"] = "file";
            Attributes["name"] = name;
        }

        public IFileTag FileTypesAccepted(string fileTypesAccepted)
        {
            Attributes["accept"] = fileTypesAccepted;
            return this;
        }
    }
}
namespace Chronologie.Class
{
    public class Tag
    {
        public string Id {get; set;}
        public string TagName {get; set;}
        public string Description{get; set;}
        public string ImageUrl {get; set;}

        public Tag(string id, string tagName, string description, string imageUrl)
        {
            Id = id;
            TagName = tagName;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
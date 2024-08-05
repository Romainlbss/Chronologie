using MySqlConnector;
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


        public static List<Tag> GetTags()
        {
            List<Tag> tags= new List<Tag>();

            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "SELECT * FROM category";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        using(MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while(r.Read())
                            {
                                Tag tag = new Tag(
                                    r.GetString(0),
                                    r.GetString(1),
                                    r.GetString(2),
                                    r.GetString(3)
                                );
                                tags.Add(tag);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("GetTags " + ex.Message);
                }
                
            }
            return tags;
        }
    }
}
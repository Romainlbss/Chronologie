using MySqlConnector;
namespace Chronologie.Class
{
    public class Tag
    {
        public int Id {get; set;}
        public string TagName {get; set;}
        public string Description{get; set;}
        public string ImageUrl {get; set;}

        public Tag(int id, string tagName, string description, string imageUrl)
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
                                    r.GetInt32(3),
                                    r.GetString(0),
                                    r.GetString(1),
                                    r.GetString(2)
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
        public static void AddTag(string name, string description, string imageUrl)
        {   
            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "INSERT INTO category (name, description, imageUrl) VALUES (@name, @description, @imageUrl)";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        cmd.Parameters.AddWithValue("@name", name);
                        cmd.Parameters.AddWithValue("@description", description);
                        cmd.Parameters.AddWithValue("@imageUrl", imageUrl);

                        int rowAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("AddTag " + ex.Message);
                }
                
            }
        }

        public static void DeleteTag(int id)
        {   
            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "DELETE FROM category WHERE id = @id";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        cmd.Parameters.AddWithValue("@id", id);

                        int rowAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("AddTag " + ex.Message);
                }
            }
        }
    }
}
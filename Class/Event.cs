    using MySqlConnector;
namespace Chronologie.Class
{
    public class Event
    {
        public int EventId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime EventDate { get; set; }
        public string Category{ get; set; }
        public string Location { get; set; }
        public string MediaPaths { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public Event(int eventId, int userId, string title, string description, DateTime eventDate ,string category, string location, string mediaPaths, DateTime createdAt, DateTime updatedAt){
            EventId = eventId;
            UserId = userId;
            Title = title;
            Description = description;
            EventDate = eventDate;
            Category = category;
            Location = location;
            MediaPaths = mediaPaths;
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
        }

        public static List<Event> GetListEvents()
        {
            List<Event> events= new List<Event>();

            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "SELECT * FROM events ORDER BY event_date ASC";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        using(MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while(r.Read())
                            {
                                Event e = new Event(r.GetInt32(0), 
                                                    r.GetInt32(1), 
                                                    r.GetString(2), 
                                                    r.GetString(3), 
                                                    r.GetDateTime(4), 
                                                    r.GetString(5), 
                                                    r.GetString(6), 
                                                    r.GetString(7), 
                                                    r.GetDateTime(8), 
                                                    r.GetDateTime(9));
                                events.Add(e);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("GetListEvents " + ex.Message);
                }
                
            }
            return events;
        }

        public static List<Event> GetListEventsTag(string? tag)
        {
            List<Event> events= new List<Event>();

            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "SELECT * FROM events WHERE category = @tag ORDER BY event_date ASC";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        cmd.Parameters.AddWithValue("@tag", tag);

                        using(MySqlDataReader r = cmd.ExecuteReader())
                        {
                            while(r.Read())
                            {
                                Event e = new Event(r.GetInt32(0), 
                                                    r.GetInt32(1), 
                                                    r.GetString(2), 
                                                    r.GetString(3), 
                                                    r.GetDateTime(4), 
                                                    r.GetString(5), 
                                                    r.GetString(6), 
                                                    r.GetString(7), 
                                                    r.GetDateTime(8), 
                                                    r.GetDateTime(9));
                                events.Add(e);
                            }
                        }
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("GetListEvents " + ex.Message);
                }
                
            }
            return events;
        }

        public static void AddEvent(Event e)
        {
            using(MySqlConnection c = new MySqlConnection(Global.ConnexionString))
            {
                c.Open();
                string req = "INSERT INTO events (user_id, title, description, event_date, category, location, media_path, created_at, updated_at)" +
                                        "VALUES (@user_id,@title,@description,@event_date,@category,@location,@media_path,@created_at,@updated_at)";
                try
                {
                    using(MySqlCommand cmd = new MySqlCommand(req, c))
                    {
                        cmd.Parameters.AddWithValue("@user_id", e.UserId);
                        cmd.Parameters.AddWithValue("@title", e.Title);
                        cmd.Parameters.AddWithValue("@description", e.Description);
                        cmd.Parameters.AddWithValue("@event_date", e.EventDate);
                        cmd.Parameters.AddWithValue("@category", e.Category);
                        cmd.Parameters.AddWithValue("@location", e.Location);
                        cmd.Parameters.AddWithValue("@media_path", e.MediaPaths);
                        cmd.Parameters.AddWithValue("@created_at", e.CreatedAt);
                        cmd.Parameters.AddWithValue("@updated_at", e.UpdatedAt);

                        int rowAffected = cmd.ExecuteNonQuery();
                    }
                }
                catch(Exception ex)
                {
                    throw new Exception("AddEvent " + ex.Message);
                }
                
            }
        }
    }
}

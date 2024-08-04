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
        public bool IsLong { get; set; }
        public int? EventEnd { get; set; }

        public Event(int eventId, int userId, string title, string description, DateTime eventDate ,string category, string location, string mediaPaths, DateTime createdAt, DateTime updatedAt, bool isLong, int? eventEnd){
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
            IsLong = isLong;
            EventEnd = eventEnd;
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
                                                    r.GetDateTime(9), 
                                                    r.GetBoolean(10), 
                                                    r.IsDBNull(11) ? null : r.GetInt32(11));
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
                                                    r.GetDateTime(9), 
                                                    r.GetBoolean(10), 
                                                    r.IsDBNull(11) ? null : r.GetInt32(11));
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
    }
}

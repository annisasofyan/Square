using System.Text.Json.Serialization;

namespace API.Models
{
    public class City
    {
        public int id { get; set; }
        public String name { get; set; }
        public virtual ICollection<WetherDetails> WeatherDetails { get; set; }

    }
}

using Newtonsoft.Json;

namespace API.Models
{
    public class Weather
    {
        public int id { get; set; }
        public String temperature { get; set; }
        public String humidity { get; set; }
        public String windSpeed { get; set; }
        public DateTime time { get; set; }
        [JsonIgnore]
        public virtual ICollection<WetherDetails> WeatherDetails { get; set;}
    }
}

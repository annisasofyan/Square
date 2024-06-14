using Newtonsoft.Json;

namespace API.Models
{
    public class Weather
    {
        public int id { get; set; }
        public int temperature { get; set; }
        public int humidity { get; set; }
        public int windSpeed { get; set; }
        public DateTime time { get; set; }
        public virtual ICollection<WetherDetails> WeatherDetails { get; set;}
    }
}

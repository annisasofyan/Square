using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class WetherDetails
    {
        public int id { get; set; }
        [ForeignKey("Weather")]
        public int weatherId { get; set; }
        [ForeignKey("City")]
        public int cityId { get; set; }
        public virtual Weather Weather { get; set; }
        public virtual City City { get; set; }  
    }
}

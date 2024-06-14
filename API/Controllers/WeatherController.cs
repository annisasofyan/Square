using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : BaseController<Weather, WeatherRepository, int>
    {
        private readonly WeatherRepository weatherRepository;
        public IConfiguration Configuration;

        public WeatherController(WeatherRepository repository, IConfiguration configuration) : base(repository)
        {
            this.weatherRepository = repository;
            this.Configuration = configuration;
        }
    }
}

using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : BaseController<City, CityRepository, int>
    {
        private readonly CityRepository _cityRepository;
        public IConfiguration Configuratio;

        public CityController(CityRepository repository, IConfiguration configuration) : base(repository)
        {
            this._cityRepository = repository;
            this.Configuratio = configuration;
        }
    }
}

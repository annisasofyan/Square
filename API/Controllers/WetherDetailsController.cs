using API.Base;
using API.Migrations;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WetherDetailsController : BaseController<WetherDetails, WetherDetailsRepository, int>
    {
        private readonly WetherDetailsRepository _repository;   
        public IConfiguration _Configuration;

        public WetherDetailsController(WetherDetailsRepository repository, IConfiguration configuration) : base(repository)
        {
            this._repository = repository;
            this._Configuration = configuration;
        }
    }
}

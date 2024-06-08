using API.Base;
using API.Models;
using API.Repository.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SquareController : BaseController<Square, SquareRepository, int>
    {
        private readonly SquareRepository squareRepository;
        public IConfiguration _Configuration;

        public SquareController(SquareRepository repository, IConfiguration configuration) : base(repository)
        {   this.squareRepository = repository;
            this._Configuration = configuration;
        }
        [Authorize]
        [Route("Random")]
        [HttpGet]
        public ActionResult Random()
        {
            try
            {
                var result = squareRepository.Random();
                if (result != null)
                {
                    return Ok(new { Status = StatusCodes.Status200OK, Result = result, Message = "Data Found" });
                }
                else
                {
                    return NotFound(new { Status = StatusCodes.Status404NotFound, Message = "Data Not Found" });
                }
            }
            catch (Exception e)
            {
                return BadRequest(new { Status = StatusCodes.Status417ExpectationFailed, ErrorMessage = e.Message });
            }
        }
    }
}

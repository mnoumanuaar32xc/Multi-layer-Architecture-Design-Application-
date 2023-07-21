using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NK.Infrastructure;
using NK.SharedModel;

namespace NK.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly IServices _services;
        private readonly IConfiguration _configuration;
        public TasksController(IServices services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;
        }
        [AllowAnonymous]
        [HttpGet("Test")]
        public IActionResult Get()
        {
            GenericResponseModel response = new();
            try
            {
                response.ResponseStatus.SetAsSuccess();
                response.ResponseStatus.Message = "NK Api is Alive";
                response.ResponseStatus.IsSuccess = true;
            }
            catch (Exception ex)
            {

                throw new CustomExceptions(ex.Message);

            }




            return Ok(response);

        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NK.Infrastructure;
using NK.Model.DBModel;
using NK.Model.RequestModel;
using NK.Model.ResponseModel;
using NK.SharedModel;

namespace NK.Api.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IServices _services;

        public UsersController(IServices services)
        {
            _services = services;

        }

        [HttpGet("Test")]
        public IActionResult Get()
        {
            GenericResponseModel response = new();

            response.ResponseStatus.SetAsSuccess();
            response.ResponseStatus.Message = "NK Api is Alive";
            response.ResponseStatus.IsSuccess = true;
            return Ok(response);

        }

        [HttpPost("GetUserById")]
        public async Task<UserResponseModel.GetUser> GetUserById([FromBody] UserRequestModel.GetUser model)
        {
            UserResponseModel.GetUser response = new();
            try
            {

                response.Users = await _services.GetUserById(model.ID);
                response.ResponseStatus.SetAsSuccess();
                response.ResponseStatus.IsSuccess = true;
            }
            catch (Exception ex)
            {
                response.ResponseStatus.SetAsFailed(ex.Message);
                response.ResponseStatus.IsSuccess = false;

            }

            return response;


        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<GenericResponseModel> login(string userName,string password)
        {
            GenericResponseModel response = new();
            if (userName == "nouman" && password == "123")
            { 
            }

                return response;



        }

    }
}

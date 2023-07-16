using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.IdentityModel.Tokens;
using NK.Infrastructure;
using NK.Model.DBModel;
using NK.Model.RequestModel;
using NK.Model.ResponseModel;
using NK.SharedModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NK.Api.Controllers
{

    //[Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private readonly IServices _services;
        private readonly IConfiguration _configuration;
        public UsersController(IServices services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration; 
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
        public async Task<GenericResponseModel> login([FromBody]  UserRequestModel.Login model)
        {
            GenericResponseModel response = new();
            if (model.UserName == "nouman" && model.Password == "123")
            { 
            }
            //create claims details based on the user information
            var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", "01"),
                        new Claim("DisplayName", model.UserName),
                        new Claim("UserName",model.UserName),
                        new Claim("Email", "nouman@sme.gov.om")
                    };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddMinutes(10),
                signingCredentials: signIn);

            response.ResponseStatus.Tokens.TokenValue=(new JwtSecurityTokenHandler().WriteToken(token));

            response.ResponseStatus.IsSuccess = true;

                return response;



        }

    }
}

using Azure.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;
using NK.Infrastructure;
using NK.Model.DBModel;
using NK.SharedModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace NK.Api.Controllers
{

    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    //[ServiceFilter(typeof(LoggingActionFilter))] 

    public class UsersController : ControllerBase
    {
        private readonly IUserServices _services;
        private readonly IConfiguration _configuration;
        private readonly IMemoryCache _cache;
        private const string _cacheKey = "abc123";
        //  public UserResponseModel.GetUser response = new();
        public UsersController(IUserServices services, IConfiguration configuration, IMemoryCache cache)
        {
            _services = services;
            _configuration = configuration;
            _cache = cache;
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

        [HttpPost("GetUserById")]
        public async Task<UserResponseModel.GetUser> GetUserById([FromBody] UserRequestModel.GetUser model)
        {
            //Sliding Expiration - If no requests are made for 10 seconds, the data will be cleared in the In-Memory cache.
            //Absolute Expiration - is the value defining for how long the cached data shold live, no matter how many times the data is requested.

            if (!_cache.TryGetValue(CacheKeys.Users, out UserResponseModel.GetUser response))
            {
                try
                {
                    response = new();
                    response.Users = await _services.GetUserById(model.ID);
                    response.ResponseStatus.SetAsSuccess();
                    response.ResponseStatus.IsSuccess = true;
                    var cacheEntryOptions = new MemoryCacheEntryOptions
                    {
                        AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                        SlidingExpiration = TimeSpan.FromMinutes(2),
                        Size = 1024,
                    };
                    _cache.Set(CacheKeys.Users, response, cacheEntryOptions);
                }
                catch (Exception ex)
                {
                    response.ResponseStatus.SetAsFailed(ex.Message);
                    response.ResponseStatus.IsSuccess = false;
                }
            }
            else
            {
                if (model.ID != response.Users[0].ID)
                {
                    response.Users = await _services.GetUserById(model.ID);

                }
                
                response.ResponseStatus.IsMemory = true;
            }

            return response;


        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<GenericResponseModel> login([FromBody] UserRequestModel.Login model)
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

            response.ResponseStatus.Tokens.TokenValue = (new JwtSecurityTokenHandler().WriteToken(token));

            response.ResponseStatus.IsSuccess = true;

            return response;



        }

        [AllowAnonymous]
        [HttpPost("AddUpdateAsync")]
        public async Task<UserResponseModel.User_AddUpdate> AddUpdateAsync([FromBody] UserRequestModel.User_AddUpdate model)
        {

            UserResponseModel.User_AddUpdate response = new();
            try
            {

                response.ReturnId = await _services.User_AddUpdate(model.User);
                response.ResponseStatus.SetAsSuccess();
                response.ResponseStatus.IsSuccess = true;
            }
            catch (Exception ex)
            {

                response.ReturnId = 0;
                response.ResponseStatus.SetAsFailed(ex.Message);
                response.ResponseStatus.IsSuccess = false;

            }

            return response;




        }




    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NK.Infrastructure;
using NK.Model.DBModel;
using NK.SharedModel;

namespace NK.Api.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    [Authorize]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _services;
        private readonly IConfiguration _configuration;
        public TasksController(ITasksServices services, IConfiguration configuration)
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


        [AllowAnonymous]
        [HttpPost("AddUpdateAsync")]
        public async Task<TaskResponseModel.Task_AddUpdate> AddUpdateAsync([FromBody] TaskRequestModel.Task_AddUpdate model)
        {

            TaskResponseModel.Task_AddUpdate response = new();
            try
            {

                response.ReturnId = await _services.Task_AddUpdate(model.Task);
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

        [HttpPost("Search")]
                public async Task<TaskResponseModel.TaskSearch> Search([FromBody] TaskRequestModel.Search model)
        {
            TaskResponseModel.TaskSearch response = new();
            try
            {

                response.Tasks = await _services.Search(model);
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

    }
}

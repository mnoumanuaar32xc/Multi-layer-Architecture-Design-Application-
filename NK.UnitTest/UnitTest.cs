using Newtonsoft.Json;
using NK.Api.Controllers;
using NK.Model.DBModel;
using NUnit.Framework.Interfaces;
using Xunit;
using static NK.Model.DBModel.UserRequestModel;

namespace NK.UnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void AddUpdateAsync()
        {

            UserRequestModel.User_AddUpdate model = new UserRequestModel.User_AddUpdate();
            Users user= new Users();

            user.UserName = "Nouman";
            user.Password = "123";
            user.Name = "Muhammad Nouman khan";
            user.Address = "Pakistan";
            model.User=user;
            string output = JsonConvert.SerializeObject(model);

            //Assert.Pass();
        }


        [Test]
        public void Task_AddUpdateAsync()
        {
            //        

            TaskRequestModel.Task_AddUpdate model = new TaskRequestModel.Task_AddUpdate();
            Tasks task = new Tasks();
            task.Title = "Project 1";
            task.Detail = "Project 1 Details ";
            task.UserID= 1;
            task.TaskTypeID = 1;
           
            
            model.Task = task;
            string output = JsonConvert.SerializeObject(model);

            //Assert.Pass();
        }
        [Test]
        public void Login()
        {
            UserRequestModel.Login model = new();
            model.UserName = "Nouman";
            model.Password = "123";

            string output = JsonConvert.SerializeObject(model);


        }


        [Test]
        public void SearchTasks()
        {
            TaskRequestModel.Search model = new();
            model.UserId = 0;
            model.TaskId = 0;
            model.TaskTypeId = 0;
            
            string output = JsonConvert.SerializeObject(model);

        }
    }
}
using Newtonsoft.Json;
using NK.Api.Controllers;
using NK.Model.DBModel;
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
    }
}
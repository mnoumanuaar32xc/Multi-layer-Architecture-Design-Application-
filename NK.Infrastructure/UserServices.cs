using NK.Model.DBModel;
using NK.Repository;

namespace NK.Infrastructure
{
    public class UserServices : IServices
    {

        private IUsersRepository _userRepository;
        public UserServices(IUsersRepository userRepository)
        {
            _userRepository = userRepository;
        }


        public async Task<List<Users>> GetUserById(int id)
        {
            List<Users> users = _userRepository.GetUserById(id);
            return users;
        }

        public async Task<long> User_AddUpdate(Users model)
        {
            long ReturnId = 0;

            ReturnId =await _userRepository.AddUpdateAsync(model);
            return ReturnId;
        }


    }
}
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



    }
}
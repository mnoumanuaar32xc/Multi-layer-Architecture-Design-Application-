using NK.Model.DBModel;

namespace NK.Infrastructure
{
    public interface IUserServices
    {
        Task<List<Users>> GetUserById(int id);
        Task<long> User_AddUpdate(Users model);
    }
}

using NK.Model.DBModel;

namespace NK.Infrastructure
{
    public interface IServices
    {
        Task<List<Users>> GetUserById(int id);

        Task<long> User_AddUpdate(Users model);
    }
}

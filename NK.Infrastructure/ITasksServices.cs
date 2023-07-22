using NK.Model.DBModel;

namespace NK.Infrastructure
{
    public interface ITasksServices
    {
        Task<long> Task_AddUpdate(Tasks model);
        Task<List<TasksExtended>> GetTasksExtendedDetailsAsync(TaskRequestModel.Search model);

    }
}

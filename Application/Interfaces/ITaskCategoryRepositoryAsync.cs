using Domain.Entities;


namespace Application.Interfaces
{
    public interface ITaskCategoryRepositoryAsync : IGenericRepositoryAsync<TaskCategory>
    {
        Task<bool> IsUniqueNameAsync(string name);

    }
}

using Domain.Entities;


namespace Application.Interfaces
{
    public interface ITaskRepositoryAsync : IGenericRepositoryAsync<WorkTask>
    {
        Task<bool> IsUniqueTitleAsync(string name);

    }
}

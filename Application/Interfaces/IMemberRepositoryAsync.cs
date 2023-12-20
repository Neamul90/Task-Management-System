using Domain.Entities;


namespace Application.Interfaces
{
    public interface IMemberRepositoryAsync : IGenericRepositoryAsync<Member>
    {
        Task<bool> IsUniqueEmailAsync(string email);
    }
}

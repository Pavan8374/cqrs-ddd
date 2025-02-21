using Identity.Domain.Entities;

namespace Identity.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
        Task<bool> ExistsAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
    }
}

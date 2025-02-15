using TechsysLog.Domain.Entities;

namespace TechsysLog.Domain.Interfaces.Persistence.Users;

public interface IUserRepository
{
    Task<User> GetByEmailAsync(string email);

    Task<User> GetByEmailAndPasswordAsync(string email, string password);

    Task<User> GetByIdAsync(Guid id);

    Task AddAsync(User user);

    Task UpdateAsync(User user);

    Task DeleteAsync(Guid id);

    Task<List<User>> GetAllAsync();
}
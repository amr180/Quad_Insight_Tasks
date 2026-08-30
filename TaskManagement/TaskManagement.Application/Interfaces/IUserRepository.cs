using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByIdAsync(int id);

    Task<IEnumerable<User>> GetAllAsync();

    Task AddAsync(User user);

    void Update(User user);

    void Delete(User user);

    Task<bool> ExistsAsync(int id);
}
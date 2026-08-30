using TaskManagement.Application.DTOs.Users;

namespace TaskManagement.Application.Interfaces;

public interface IUserService
{
    Task<int> CreateAsync(CreateUserDto dto);

    Task<IEnumerable<object>> GetAllAsync();

    Task<object?> GetByIdAsync(int id);

    Task UpdateAsync(
        int id,
        UpdateUserDto dto);

    Task DeleteAsync(int id);
}
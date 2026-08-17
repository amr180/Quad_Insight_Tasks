using TaskManagement.Application.DTOs.Users;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public UserService(
        IUserRepository userRepository,
        IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreateAsync(CreateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ArgumentException("Email is required.");

        var user = new User(
            dto.Name,
            dto.Email);

        await _userRepository.AddAsync(user);

        await _unitOfWork.SaveChangesAsync();

        return user.Id;
    }

    public async Task<IEnumerable<object>> GetAllAsync()
    {
        var users = await _userRepository.GetAllAsync();

        return users.Select(user => new
        {
            user.Id,
            user.Name,
            user.Email,

            Tasks = user.Tasks.Select(task => new
            {
                task.Id,
                task.Title,
                task.Description,
                task.Status,
                task.CreatedAt
            })
        });
    }

    public async Task<object?> GetByIdAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            return null;

        return new
        {
            user.Id,
            user.Name,
            user.Email,

            Tasks = user.Tasks.Select(task => new
            {
                task.Id,
                task.Title,
                task.Description,
                task.Status,
                task.CreatedAt
            })
        };
    }

    public async Task UpdateAsync(
        int id,
        UpdateUserDto dto)
    {
        if (string.IsNullOrWhiteSpace(dto.Name))
            throw new ArgumentException("Name is required.");

        if (string.IsNullOrWhiteSpace(dto.Email))
            throw new ArgumentException("Email is required.");

        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new KeyNotFoundException("User not found.");

        user.Update(
            dto.Name,
            dto.Email);

        _userRepository.Update(user);

        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetByIdAsync(id);

        if (user is null)
            throw new KeyNotFoundException("User not found.");

        _userRepository.Delete(user);

        await _unitOfWork.SaveChangesAsync();
    }
}
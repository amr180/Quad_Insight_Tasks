using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Interfaces;
using TaskManagement.Domain.Entities;
using TaskManagement.Infrastructure.Data;

namespace TaskManagement.Infrastructure.Repositories;

public class TaskRepository : ITaskRepository
{
    private readonly AppDbContext _context;

    public TaskRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<TaskItem?> GetByIdAsync(int id)
    {
        return await _context.TaskItems
            .Include(t => t.User)
            .FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task<IEnumerable<TaskItem>> GetAllAsync()
    {
        return await _context.TaskItems
            .Include(t => t.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<IEnumerable<TaskItem>> GetByUserIdAsync(int userId)
    {
        return await _context.TaskItems
            .Where(t => t.UserId == userId)
            .Include(t => t.User)
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task AddAsync(TaskItem task)
    {
        await _context.TaskItems.AddAsync(task);
    }

    public void Update(TaskItem task)
    {
        _context.TaskItems.Update(task);
    }

    public void Delete(TaskItem task)
    {
        _context.TaskItems.Remove(task);
    }

    public async Task<bool> ExistsAsync(int id)
    {
        return await _context.TaskItems
            .AnyAsync(t => t.Id == id);
    }
}

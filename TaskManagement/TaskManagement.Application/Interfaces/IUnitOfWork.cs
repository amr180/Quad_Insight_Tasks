namespace TaskManagement.Application.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync();
}
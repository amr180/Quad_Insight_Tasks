using Microsoft.EntityFrameworkCore;
using TaskMangament.TaskMangament.Domin.Entities;

namespace TaskMangament.TaskManagement.Infrastructure.Data
{
    public DbSet<User> Users { get; set; }

    public DbSet<TaskItem> Tasks { get; set; }
}

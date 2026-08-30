using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs.Tasks;

public class CreateTaskDto
{
    //in first varsion
    //public string Title { get; set; } = string.Empty;

    //public string? Description { get; set; }

    //public int? UserId { get; set; }

    //public int? ParentTaskId { get; set; }

    //updated version
    [Required(ErrorMessage = "Task title is required.")]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    [Required(ErrorMessage = "User ID is required.")]
    public int UserId { get; set; }

    public int? ParentTaskId { get; set; }
}
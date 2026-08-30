using System.ComponentModel.DataAnnotations;

namespace TaskManagement.Application.DTOs.Tasks;

public class UpdateTaskDto
{
    [Required]
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }
    [Required]
    public int UserId { get; set; }
}
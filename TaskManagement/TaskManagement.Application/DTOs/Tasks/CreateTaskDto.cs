namespace TaskManagement.Application.DTOs.Tasks;

public class CreateTaskDto
{
    public string Title { get; set; } = string.Empty;

    public string? Description { get; set; }

    public int? UserId { get; set; }
}
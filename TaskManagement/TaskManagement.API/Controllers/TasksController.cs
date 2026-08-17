using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Tasks;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TasksController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    // GET all tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
 
        var tasks = await _taskService.GetAllAsync();
        if (tasks == null)
        {
            return NotFound(new
            {
                message = "No tasks found."
            });
        }
        else
        return Ok(tasks);
    }

    // get task by id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _taskService.GetByIdAsync(id);

        if (task is null)
            return NotFound(new
            {
                message = "the Task not found."
            });

        return Ok(task);
    }

    // Create a new task
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateTaskDto dto)
    {
        var id = await _taskService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new
            {
                id,
                message = "Task created successfully."
            });
    }

    // update task by id
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateTaskDto dto)
    {
        await _taskService.UpdateAsync(id, dto);

        return Ok(new
        {
            message = "Task updated successfully."
        });
    }

    //delete task by id
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _taskService.DeleteAsync(id);

        return Ok(new
        {
            message = "Task deleted successfully."
        });
    }

    // update task status by id
    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(
        int id,
        [FromBody] UpdateTaskStatusDto dto)
    {
        await _taskService.UpdateStatusAsync(id, dto);
        if (_taskService == null)
        {
            return NotFound(new
            {
                message = "Task not found."
            });
        }
        else
        {
            return Ok(new
            {
                message = "Task status updated successfully."
            });
        }
    }
    // get tasks by user id
    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var tasks = await _taskService.GetByUserIdAsync(userId);

        return Ok(tasks);
    }

    // get subtasks by parent task id
    [HttpGet("{parentTaskId:int}/subtasks")]
    public async Task<IActionResult> GetSubTasks(
        int parentTaskId)
    {
        var subTasks =
            await _taskService.GetSubTasksAsync(parentTaskId);

        return Ok(subTasks);
    }
}
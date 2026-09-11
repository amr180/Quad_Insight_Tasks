using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Tasks;
//using TaskManagement.Application.Interfaces;
using TaskManagement.Application.Tasks.Commands.CreateTask;
using TaskManagement.Application.Tasks.Commands.DeleteTask;
using TaskManagement.Application.Tasks.Commands.UpdateTask;
using TaskManagement.Application.Tasks.Commands.UpdateTaskStatus;
using TaskManagement.Application.Tasks.Queries.GetAllTasks;
using TaskManagement.Application.Tasks.Queries.GetTaskById;
using TaskManagement.Application.Tasks.Queries.GetTasksByUserId;
namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
//public class TasksController : ControllerBase
//{
//    private readonly ITaskService _taskService;

//    public TasksController(ITaskService taskService)
//    {
//        _taskService = taskService;
//    }
public class TasksController : ControllerBase
{
    private readonly IMediator _mediator;

    public TasksController(IMediator mediator)
    {
        _mediator = mediator;
    }
    // GET all tasks
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var tasks = await _mediator.Send(new GetAllTasksQuery());

        if (tasks == null)
        {
            return NotFound(new
            {
                message = "No tasks found."
            });
        }

        return Ok(tasks);
    }

    // get task by id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var task = await _mediator.Send(new GetTaskByIdQuery(id));

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
        var id = await _mediator.Send(
            new CreateTaskCommand(dto.Title, dto.Description, dto.UserId));

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
        await _mediator.Send(
            new UpdateTaskCommand(id, dto.Title, dto.Description, dto.UserId));

        return Ok(new
        {
            message = "Task updated successfully."
        });
    }

    //delete task by id
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _mediator.Send(new DeleteTaskCommand(id));

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
        await _mediator.Send(new UpdateTaskStatusCommand(id, dto.Status));

        return Ok(new
        {
            message = "Task status updated successfully."
        });
    }

    // get tasks by user id
    [HttpGet("user/{userId:int}")]
    public async Task<IActionResult> GetByUserId(int userId)
    {
        var tasks = await _mediator.Send(new GetTasksByUserIdQuery(userId));

        return Ok(tasks);
    }
}

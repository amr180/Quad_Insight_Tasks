using Microsoft.AspNetCore.Mvc;
using TaskManagement.Application.DTOs.Users;
using TaskManagement.Application.Interfaces;

namespace TaskManagement.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }
    ////done
    //get all users
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await _userService.GetAllAsync();

        return Ok(users);
    }
    //done
    // get user by id
    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetById(int id)
    {
        var user = await _userService.GetByIdAsync(id);

        if (user is null)
            return NotFound(new
            {
                message = "User not found."
            });

        return Ok(user);
    }
    //done
    // post create user
    [HttpPost]
    public async Task<IActionResult> Create(
        [FromBody] CreateUserDto dto)
    {
        var id = await _userService.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id },
            new
            {
                id,
                message = "User created successfully."
            });
    }
    //done
    // update user by id
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateUserDto dto)
    {
        await _userService.UpdateAsync(id, dto);

        return Ok(new
        {
            message = "User updated successfully."
        });
    }
    //done
    // delete user by id
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _userService.DeleteAsync(id);

        return Ok(new
        {
            message = "User deleted successfully."
        });
    }
}
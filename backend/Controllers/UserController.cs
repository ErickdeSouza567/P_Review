using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P_Review.ApiMovie.DTOs;
using P_Review.ApiMovie.Models;
using P_Review.ApiMovie.Services;
using System.Data;

namespace P_Review.ApiMovie.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDTO>>> Get()
    {
        var usersDto = await _userService.GetUsers();
        if (usersDto == null)
        {
            return NotFound("Users not found");
        }
        return Ok(usersDto);
    }

    [HttpGet("movies")]
    public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersMovies()
    {
        var usersDto = await _userService.GetUserMovies();
        if (usersDto == null)
        {
            return NotFound("Users not found");
        }
        return Ok(usersDto);
    }

    [HttpGet("{id:int}", Name = "GetUser")]
    public async Task<ActionResult<UserDTO>> Get(int id)
    {
        var userDto = await _userService.GetUserById(id);
        if (userDto == null)
        {
            return NotFound("User not found");
        }
        return Ok(userDto);
    }

    [HttpPost]
    public async Task<ActionResult> Post([FromBody] UserDTO userDto)
    {
        if (userDto == null)
            return BadRequest("Invalid Data");

        await _userService.AddUser(userDto);

        return new CreatedAtRouteResult("GetUser", new { id = userDto.UserId },
            userDto);
    }


    [HttpPut("{id:int}")]
    public async Task<ActionResult> Put(int id, [FromBody] UserDTO userDto)
    {
        if (id != userDto.UserId)
            return BadRequest();

        if (userDto == null)
            return BadRequest();

        await _userService.UpdateUser(userDto);

        return Ok(userDto);
    }

    [HttpDelete("{id:int}")]
    public async Task<ActionResult<UserDTO>> Delete(int id)
    {
        var userDto = await _userService.GetUserById(id);
        if (userDto == null)
        {
            return NotFound("User not found");
        }

        await _userService.RemoveUser(id);

        return Ok(userDto);
    }
}
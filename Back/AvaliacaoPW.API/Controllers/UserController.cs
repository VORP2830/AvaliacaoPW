using AvaliacaoPW.API.Extensions;
using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoPW.API.Controllers;
[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<IActionResult> GetById()
    {
        var result = await _userService.GetById(User.GetUserId());
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("Create")]
    public async Task<IActionResult> Create(UserDto model)
    {
        var result = await _userService.Create(model);
        return Ok(result);
    }

    [AllowAnonymous]
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginDto model)
    {
        var result = await _userService.Login(model);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Update(UserDto model)
    {
        var result = await _userService.Update(model, User.GetUserId());
        return Ok(result);
    }
}

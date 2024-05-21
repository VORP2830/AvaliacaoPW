using AvaliacaoPW.Application.Dtos;
using AvaliacaoPW.Application.Interfaces;
using AvaliacaoPW.Domain.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AvaliacaoPW.API.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;
    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _service.GetById(id);
        return Ok(result);
    }
    [HttpGet]
    public async Task<IActionResult> GetPaginated([FromQuery] PageParams pageParams)
    {
        var result = await _service.GetPaginated(pageParams);
        return Ok(result);
    }
    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAll();
        return Ok(result);
    }
    [HttpPost]
    public async Task<IActionResult> Post(EmployeeDto model)
    {
        var result = await _service.Create(model);
        return Ok(result);
    }
    [HttpPut]
    public async Task<IActionResult> Put(EmployeeDto model)
    {
        var result = await _service.Update(model);
        return Ok(result);
    }
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var result = await _service.Delete(id);
        return Ok(result);
    }
}

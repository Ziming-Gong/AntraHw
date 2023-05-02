using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class InterviewType : ControllerBase
{
    private readonly IInterviewTypeService _service;

    public InterviewType(IInterviewTypeService interviewTypeService)
    {
        _service = interviewTypeService;
    }

    [HttpGet("GetInterviewTypeById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("GetAllInterviewType")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _service.DeleteByIdAsync(id));
    }

    [HttpPost("CreateInterviewType")]
    public async Task<IActionResult> Create(InterviewTypeRequestModel model)
    {
        return Ok(await _service.InsertAsync(model));
    }

    [HttpPut("UpdateInterviewType")]
    public async Task<IActionResult> Update(InterviewTypeRequestModel model)
    {
        return Ok(await _service.UpdateAsync(model));
    }
}
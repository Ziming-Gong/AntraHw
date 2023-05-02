using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;
[Route("/api/[controller]")]
[ApiController]
public class InterviewerController : Controller
{
    private readonly IInterviewerService _service;

    public InterviewerController(IInterviewerService interviewerService)
    {
        _service = interviewerService;
    }
    [HttpGet("GetInterviewerById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("GetAllInterviewer")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _service.DeleteByIdAsync(id));
    }

    [HttpPost("CreateInterviewer")]
    public async Task<IActionResult> Create(InterviewerRequestModel model)
    {
        return Ok(await _service.InsertAsync(model));
    }

    [HttpPut("UpdateInterviewer")]
    public async Task<IActionResult> Update(InterviewerRequestModel model)
    {
        return Ok(await _service.UpdateAsync(model));
    }
}
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;
[Route("/api/[controller]")]
[ApiController]
public class InterviewController : Controller
{
    private readonly IInterviewService _service;

    public InterviewController(IInterviewService interviewService)
    {
        _service = interviewService;
    }
    [HttpGet("GetInterviewById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("GetAllInterview")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _service.DeleteByIdAsync(id));
    }

    [HttpPost("CreateInterview")]
    public async Task<IActionResult> Create(InterviewRequestModel model)
    {
        return Ok(await _service.InsertAsync(model));
    }

    [HttpPut("UpdateInterview")]
    public async Task<IActionResult> Update(InterviewRequestModel model)
    {
        return Ok(await _service.UpdateAsync(model));
    }
}
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class InterviewFeedbackController : Controller
{
    private readonly IInterviewFeedBackService _service;

    public InterviewFeedbackController(IInterviewFeedBackService feedBackService)
    {
        _service = feedBackService;
    }
    [HttpGet("GetInterviewFeedbackById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _service.GetByIdAsync(id));
    }

    [HttpGet("GetAllInterviewFeedback")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _service.GetAllAsync());
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _service.DeleteByIdAsync(id));
    }

    [HttpPost("CreateInterviewFeedback")]
    public async Task<IActionResult> Create(InterviewFeedbackRequestModel model)
    {
        return Ok(await _service.InsertAsync(model));
    }

    [HttpPut("UpdateInterviewFeedback")]
    public async Task<IActionResult> Update(InterviewFeedbackRequestModel model)
    {
        return Ok(await _service.UpdateAsync(model));
    }
}
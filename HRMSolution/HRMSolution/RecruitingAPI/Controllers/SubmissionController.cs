using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Models;

namespace RecruitingAPI.Controllers;

[Route("/api/[controller]")]
[ApiController]
public class SubmissionController : ControllerBase
{
    private readonly ISubmissionService _submissionService;

    public SubmissionController(ISubmissionService submissionService)
    {
        _submissionService = submissionService;
    }
    [HttpPost]
    [Route("AddSubmissionStatus")]
    public async Task<IActionResult> AddSubmissionStatus(SubmissionRequestModel submissionStatusRequestModel)
    {
        return Ok(await _submissionService.AddSubmissionAsync(submissionStatusRequestModel));
    }

    [HttpGet]
    [Route("GetAllSubmissionStatus")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _submissionService.GetAllSubmissionAsync());
    }

    [HttpGet]
    [Route("getstatusbyid/{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        return Ok(await _submissionService.GetSubmissionByIdAsync(id));
    }

    [HttpPut]
    [Route("updatesubmissionstatus")]
    public async Task<IActionResult> UpdateStatus(SubmissionRequestModel model)
    {
        return Ok(await _submissionService.UpdateSubmissionAsync(model));
    }

    [HttpDelete]
    [Route("deletesubmissionstatus")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
        return Ok(await _submissionService.DeleteSubmissionAsync(id));
    }

}
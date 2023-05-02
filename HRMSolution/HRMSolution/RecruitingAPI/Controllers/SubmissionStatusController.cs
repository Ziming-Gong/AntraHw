using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Repository;

namespace RecruitingAPI.Controllers;

[Route("api/SubmissionStatus")]
[ApiController]
public class SubmissionStatusController : ControllerBase
{
    private readonly ISubmissionStatusService _submissionStatusService;
    public SubmissionStatusController(ISubmissionStatusService submissionStatusService)
    {
        _submissionStatusService = submissionStatusService;
    }
    [HttpPost]
    [Route("AddSubmissionStatus")]
    public async Task<IActionResult> AddSubmissionStatus(SubmissionStatusRequestModel submissionStatusRequestModel)
    {
        return Ok(await _submissionStatusService.AddStatusAsync(submissionStatusRequestModel));
    }

    [HttpGet]
    [Route("GetAllSubmissionStatus")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _submissionStatusService.GetAllStatus());
    }

    [HttpGet]
    [Route("getstatusbyid/{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        return Ok(await _submissionStatusService.GetStatusByIdAsync(id));
    }

    [HttpPut]
    [Route("updatesubmissionstatus")]
    public async Task<IActionResult> UpdateStatus(SubmissionStatusRequestModel model)
    {
        return Ok(await _submissionStatusService.UpdateStatusAsync(model));
    }

    [HttpDelete]
    [Route("deletesubmissionstatus")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
        return Ok(await _submissionStatusService.DeleteStatusAsync(id));
    }
    
    
    



}
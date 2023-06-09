using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Models;

namespace RecruitingAPI.Controllers;

public class JobRequirementController : Controller
{
    private readonly IJobRequirementService _jobRequirementService;

    public JobRequirementController(IJobRequirementService jobRequirementService )
    {
        _jobRequirementService = jobRequirementService;
    }
    [HttpPost]
    [Route("AddJobRequirement")]
    public async Task<IActionResult> AddSubmissionStatus(JobRequirementRequestModel model)
    {
        return Ok(await _jobRequirementService.AddJobRequirementAsync(model));
    }

    [HttpGet]
    [Route("GetAllJobRequirement")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _jobRequirementService.GetAllJobRequirements());
    }

    [HttpGet]
    [Route("GetJobRequirementById/{id}")]
    public async Task<IActionResult> GetStatusById(int id)
    {
        return Ok(await _jobRequirementService.GetJobRequirementByIdAsync(id));
    }

    [HttpPut]
    [Route("UpdateJobRequirement")]
    public async Task<IActionResult> UpdateStatus(JobRequirementRequestModel model)
    {
        return Ok(await _jobRequirementService.UpdateJobRequirementAsync(model));
    }

    [HttpDelete]
    [Route("DeleteJobRequirement")]
    public async Task<IActionResult> DeleteStatus(int id)
    {
        return Ok(await _jobRequirementService.DeleteJobRequirementAsync(id));
    }
}
using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;
using ILogger = Microsoft.Build.Framework.ILogger;

namespace RecruitingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : Controller
{
    private readonly ICandidateServiceAsync _candidateService;
    // private readonly ILogger _logger;
    public CandidateController(ICandidateServiceAsync candidateServiceAsync )
    {
        this._candidateService = candidateServiceAsync;
    }
    [HttpGet]
    [Route("GetAllCandidate")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _candidateService.GetAllCandidateAsync());
    }

    [HttpPost]
    [Route("CreateCandidate")]
    public async Task<IActionResult> Post(CandidateRequestModel candidate)
    {
        return Ok(await _candidateService.AddCandidateAsync(candidate));
    }

    [HttpGet]
    [Route("GetCandidateById/{id}")]
    public async Task<IActionResult> GetCandidateById(int id)
    {
        // try
        // {
            var candidate = await _candidateService.GetCandidateByIdAsync(id);
            return Ok(candidate);

        // }
        // catch (Exception e)
        // {
        //     _logger.LogCritical(e, "In get id ");
        //     throw e;
        // }
    }

    [HttpDelete]
    [Route("DeleteCandidateById/{id}")]
    public async Task<IActionResult> DeleteCandidateById(int id)
    {
        return Ok(await _candidateService.DeleteCandidateAsync(id));
    }

    [HttpPut]
    [Route("update")]
    public async Task<IActionResult> Update(CandidateRequestModel model)
    {
        return Ok(await _candidateService.UpdateCandidateAsync(model));
    }
}
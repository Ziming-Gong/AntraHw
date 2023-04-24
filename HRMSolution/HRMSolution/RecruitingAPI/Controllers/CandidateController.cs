using Microsoft.AspNetCore.Mvc;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;

namespace RecruitingAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CandidateController : Controller
{
    private readonly ICandidateServiceAsync _candidateService;
    public CandidateController(ICandidateServiceAsync candidateServiceAsync)
    {
        this._candidateService = candidateServiceAsync;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _candidateService.GetAll());
    }

    [HttpPost]
    public async Task<IActionResult> Post(Candidate candidate)
    {
        return Ok(await _candidateService.AddCandidateAsync(candidate));
    }
}
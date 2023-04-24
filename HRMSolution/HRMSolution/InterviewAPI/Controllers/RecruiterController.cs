using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruiterController : Controller
{

    private readonly IRecruiterService _recruiterService;
    public RecruiterController(IRecruiterService _recruiterService)
    {
        this._recruiterService = _recruiterService;
    }
    [HttpGet]
    [Route("GetAllRecruiter")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(_recruiterService.GetAll());
    }

    [HttpPost]
    [Route("AddRecruiter")]
    public async Task<IActionResult> CreateRecruiter(RecruiterRequestModel model)
    {
        return Ok(_recruiterService.AddRecruiter(model));
    }

    [HttpGet]
    [Route("GetRecruiterById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(_recruiterService.GetById(id));
    }
}
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Service;
using Microsoft.AspNetCore.Mvc;

namespace InterviewAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecruiterController : ControllerBase
{

    private readonly IRecruiterService _recruiterService;
    public RecruiterController(IRecruiterService recruiterService)
    {
        this._recruiterService = recruiterService;
    }
    [HttpGet]
    [Route("GetAllRecruiter")]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await _recruiterService.GetAllAsync());
    }

    [HttpPost]
    [Route("AddRecruiter")]
    public async Task<IActionResult> CreateRecruiter(RecruiterRequestModel model)
    {
        return Ok(await _recruiterService.InsertAsync(model));
    }

    [HttpGet]
    [Route("GetRecruiterById")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _recruiterService.GetByIdAsync(id));
    }

    [HttpDelete("DeleteById")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _recruiterService.DeleteByIdAsync(id));
    }

    [HttpPut("Update")]
    public async Task<IActionResult> Update(RecruiterRequestModel model)
    {
        return Ok(await _recruiterService.UpdateAsync(model));
    }
}
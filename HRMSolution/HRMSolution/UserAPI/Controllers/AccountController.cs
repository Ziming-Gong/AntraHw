using Microsoft.AspNetCore.Mvc;
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Models;

namespace UserAPI.Controllers;

public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService service)
    {
        _accountService = service;
    }

    [HttpGet("GetAll")]
    public async Task<ActionResult> GetAll()
    {
        return Ok(await _accountService.GetAllAccountAsync());
    }

    [HttpGet("getbyid")]
    public async Task<IActionResult> GetById(int id)
    {
        return Ok(await _accountService.GetAccountByIdAsync(id));
    }

    [HttpDelete("DeleteAccount/{id}")]
    public async Task<IActionResult> DeleteById(int id)
    {
        return Ok(await _accountService.DeleteAccountByIdAsync(id));
    }

    [HttpPost("CreateAccount")]
    public async Task<IActionResult> CreateAccount(AccountRequestModel model)
    {
        return Ok(await _accountService.CreateAccountAsync(model));
    }

    [HttpPut("UpdateAccount")]
    public async Task<IActionResult> UpdateAccount(AccountRequestModel model)
    {
        return Ok(await _accountService.UpdateAccount(model));
    }
}
using User.ApplicationCore.Constract.Repositories;
using User.ApplicationCore.Constract.Services;
using User.ApplicationCore.Entity;
using User.ApplicationCore.Exceptions;
using User.ApplicationCore.Models;
using User.Infrastructure.Helper;

namespace User.Infrastructure.Services;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;

    public AccountService(IAccountRepository accountRepository)
    {
        _accountRepository = accountRepository;
    }

    public async Task<AccountResponseModel> GetAccountByIdAsync(int id)
    {
        var res = await _accountRepository.GetById(id);
        if (res != null)
        {
            var response = res.ToAccountResponseModel();
            return response;
        }
        else
        {
            throw new NotFoundException("Account", id);
        }
    }

    public async Task<IEnumerable<AccountResponseModel>> GetAllAccountAsync()
    {
        var res = await _accountRepository.GetAll();
        var response = res.Select(x => x.ToAccountResponseModel());
        return response;
    }

    public async Task<int> DeleteAccountByIdAsync(int id)
    {
        return await _accountRepository.DeleteById(id);
    }

    public async Task<int> CreateAccountAsync(AccountRequestModel model)
    {
        var exist = await _accountRepository.GetByEmail(model.Email);
        if (exist != null)
        {
            throw new Exception("This Email is exist");
        }

        Account account = new Account();
        if (model != null)
        {
            account.UserId = model.UserId;
            account.EmployeeId = model.EmployeeId;
            account.Email = model.Email;
            account.RoleId = model.RoleId;
            account.FirstName = model.FirstName;
            account.LastName = model.LastName;
            account.HashPassWord = model.HashPassWord;
            account.Salt = model.Salt;
            return await _accountRepository.InsertAsync(account);
        }
        else
        {
            throw new Exception("Oops");
        }
    }

    public async Task<int> UpdateAccount(AccountRequestModel model)
    {
        var exist = await _accountRepository.GetById(model.UserId);
        if (exist == null)
        {
            throw new Exception("Account is not found");
        }

        Account account = new Account();
        if (model != null)
        {
            account.UserId = model.UserId;
            account.EmployeeId = model.EmployeeId;
            account.Email = model.Email;
            account.RoleId = model.RoleId;
            account.FirstName = model.FirstName;
            account.LastName = model.LastName;
            account.HashPassWord = model.HashPassWord;
            account.Salt = model.Salt;
            await _accountRepository.Update(account);
            return 1;
        }
        else
        {
            return -1;
        }

    }
}
using User.ApplicationCore.Models;

namespace User.ApplicationCore.Constract.Services;

public interface IAccountService
{
    Task<AccountResponseModel> GetAccountByIdAsync(int id);
    Task<IEnumerable<AccountResponseModel>> GetAllAccountAsync();
    Task<int> DeleteAccountByIdAsync(int id);
    Task<int> CreateAccountAsync(AccountRequestModel model);
    Task<int> UpdateAccount(AccountRequestModel model);

}
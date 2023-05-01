using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public  interface IRecruiterService
{
    Task<int> InsertAsync(RecruiterRequestModel model);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(RecruiterRequestModel model);
    Task<RecruiterResponseModel> GetByIdAsync(int id);
    Task<IEnumerable<RecruiterResponseModel>> GetAllAsync(); 
}
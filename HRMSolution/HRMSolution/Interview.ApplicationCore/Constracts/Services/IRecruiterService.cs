using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public  interface IRecruiterService
{
    Task<RecruiterResponseModel> GetByIdAsync(int id);
    Task<int> AddRecruiter(RecruiterRequestModel model);
    Task<IEnumerable<RecruiterResponseModel>> GetAll();
}
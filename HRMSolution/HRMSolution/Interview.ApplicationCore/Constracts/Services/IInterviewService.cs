using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public interface IInterviewService
{
    Task<int> InsertAsync(InterviewRequestModel model);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(InterviewRequestModel model);
    Task<InterviewResponseModel> GetByIdAsync(int id);
    Task<IEnumerable<InterviewResponseModel>> GetAllAsync();
}
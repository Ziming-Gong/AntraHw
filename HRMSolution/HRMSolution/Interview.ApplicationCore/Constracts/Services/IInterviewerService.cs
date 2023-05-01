using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public interface IInterviewerService
{
    Task<int> InsertAsync(InterviewerRequestModel model);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(InterviewerRequestModel model);
    Task<InterviewerResponseModel> GetByIdAsync(int id);
    Task<IEnumerable<InterviewerResponseModel>> GetAllAsync();
}
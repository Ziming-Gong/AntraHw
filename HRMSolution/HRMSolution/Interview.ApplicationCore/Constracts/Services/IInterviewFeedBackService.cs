using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public interface IInterviewFeedBackService
{
    Task<int> InsertAsync(InterviewFeedbackRequestModel model);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(InterviewFeedbackRequestModel model);
    Task<InterviewFeedbackResponseModel> GetByIdAsync(int id);
    Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllAsync();

}
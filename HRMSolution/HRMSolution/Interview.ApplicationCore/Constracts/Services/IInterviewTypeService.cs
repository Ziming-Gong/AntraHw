using Interview.ApplicationCore.Model;

namespace Interview.ApplicationCore.Constracts.Services;

public interface IInterviewTypeService
{
    Task<int> InsertAsync(InterviewTypeRequestModel model);
    Task<int> DeleteByIdAsync(int id);
    Task<int> UpdateAsync(InterviewTypeRequestModel model);
    Task<InterviewTypeResponseModel> GetByIdAsync(int id);
    Task<IEnumerable<InterviewTypeResponseModel>> GetAllAsync();
}
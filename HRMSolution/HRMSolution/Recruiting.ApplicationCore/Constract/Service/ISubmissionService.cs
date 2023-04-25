using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Constract.Service;

public interface ISubmissionService
{
    Task<int> AddSubmissionAsync(SubmissionRequestModel model);
    Task<int> DeleteSubmissionAsync(int id);
    Task<int> UpdateSubmissionAsync(SubmissionRequestModel model);
    Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id);
    Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync();
}
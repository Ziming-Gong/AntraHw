using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Constract.Service;

public interface ICandidateServiceAsync
{
    Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync();
    Task<int> AddCandidateAsync(CandidateRequestModel candidateRequestModel);
    Task<int> UpdateCandidateAsync(CandidateRequestModel candidateRequestModel);
    Task<int> DeleteCandidateAsync(int id);
    Task<CandidateResponseModel> GetCandidateByIdAsync(int id);

}
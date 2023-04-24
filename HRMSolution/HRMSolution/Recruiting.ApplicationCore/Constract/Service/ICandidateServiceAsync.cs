using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Constract.Service;

public interface ICandidateServiceAsync
{
    Task<IEnumerable<CandidateResponseModel>> GetAll();
    Task<int> AddCandidateAsync(CandidateRequestModel candidateRequestModel);
}
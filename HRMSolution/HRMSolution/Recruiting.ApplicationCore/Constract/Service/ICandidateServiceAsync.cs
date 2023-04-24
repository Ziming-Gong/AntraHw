using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Constract.Service;

public interface ICandidateServiceAsync
{
    Task<IEnumerable<Candidate>> GetAll();
    Task<int> AddCandidateAsync(Candidate candidate);
}
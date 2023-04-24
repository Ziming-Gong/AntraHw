using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;

namespace Recruiting.Infrastructure.Service;

public class CandidateServiceAsync : ICandidateServiceAsync
{
    private readonly ICandidateRepositoryAsync _candidateRepository;
    public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepository)
    {
        this._candidateRepository = _candidateRepository;
    }
    public Task<IEnumerable<Candidate>> GetAll()
    {
        return _candidateRepository.GetAll();
    }

    public Task<int> AddCandidateAsync(Candidate candidate)
    {
        return _candidateRepository.InsertAsync(candidate);
    }
}
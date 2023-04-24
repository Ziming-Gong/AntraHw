using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helpper;

namespace Recruiting.Infrastructure.Service;

public class CandidateServiceAsync : ICandidateServiceAsync
{
    private readonly ICandidateRepositoryAsync _candidateRepository;
    public CandidateServiceAsync(ICandidateRepositoryAsync _candidateRepository)
    {
        this._candidateRepository = _candidateRepository;
    }
    public async Task<IEnumerable<CandidateResponseModel>> GetAll()
    {
        var candidates = await _candidateRepository.GetAll();
        var response = candidates.Select(x => x.ToCandidateResponseModel());
        return response;
    }


    public Task<int> AddCandidateAsync(CandidateRequestModel candidateRequestModel)
    {
        Candidate candidate = new Candidate
        {
            Id = candidateRequestModel.Id,
            FirstName = candidateRequestModel.FirstName,
            LastName = candidateRequestModel.LastName,
            Email = candidateRequestModel.Email,
            ResumeURL = candidateRequestModel.ResumeURL
        };
        return _candidateRepository.InsertAsync(candidate);
    }
}
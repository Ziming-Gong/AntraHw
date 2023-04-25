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
    public async Task<IEnumerable<CandidateResponseModel>> GetAllCandidateAsync()
    {
        var candidates = await _candidateRepository.GetAllAsync();
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

    public async Task<int> UpdateCandidateAsync(CandidateRequestModel candidateRequestModel)
    {
        var exist = await _candidateRepository.GetByIdAsync(candidateRequestModel.Id);
        if (exist == null)
        {
            throw new Exception("Candidate is not found");
        }

        if (candidateRequestModel != null)
        {
            Candidate candidate = new Candidate
            {
                Id = candidateRequestModel.Id,
                FirstName = candidateRequestModel.FirstName,
                LastName = candidateRequestModel.LastName,
                Email = candidateRequestModel.Email,
                ResumeURL = candidateRequestModel.ResumeURL
            };
            return await _candidateRepository.UpdateAsync(candidate);
        }
        else
        {
            return -1;
        }
    }

    public async Task<int> DeleteCandidateAsync(int id)
    {
        return await _candidateRepository.DeleteAsync(id);
    }

    public async Task<CandidateResponseModel> GetCandidateByIdAsync(int id)
    {
        var candidate = await _candidateRepository.GetByIdAsync(id);
        if (candidate != null)
        {
            var response = candidate.ToCandidateResponseModel();
            return response;
        }
        else
        {
            throw new Exception("This id is not exit"); //TODO
        }
    }
}
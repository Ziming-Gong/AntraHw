using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.Infrastructure.Service;

public class SubmissionService : ISubmissionService
{
    private readonly ISubmissionRepository _submissionRepository;
    private readonly ICandidateRepositoryAsync _candidateRepository;
    public SubmissionService(ISubmissionRepository submissionRepository, ICandidateRepositoryAsync candidateRepositoryAsync)
    {
        _submissionRepository = submissionRepository;
        _candidateRepository = candidateRepositoryAsync;
    }

   //TODO
    public async Task<int> AddSubmissionAsync(SubmissionRequestModel model)
    {
        var candidate= await _candidateRepository.FirstOrDefaultWithIncludesAsync(x => x.Id == model.CandidateId,
            x => x.Submissions);
        var exist = candidate.Submissions.FirstOrDefault(e => e.JobRequirementId == model.JobRequirementId);
        if (exist == null)
        {
            throw new Exception("This Submission already exist!");
        }

        if (model != null)
        {
            Submission submission = new Submission
            {
                CandidateId = model.CandidateId,
                ConfirmedOn = model.ConfirmedOn,
                SubmissionId = model.SubmissionId,
                SubmittedOn = model.SubmittedOn,
                SubmissionStatusCode = model.SubmissionStatusCode,
                RejectedOn = model.RejectedOn
            };
            return await _submissionRepository.InsertAsync(submission);
        }
        else
        {
            return 0;
        }
    }

    public async Task<int> DeleteSubmissionAsync(int id)
    {
        //TODO
        return 1;    
    }

    public async Task<int> UpdateSubmissionAsync(SubmissionRequestModel model)
    {
        //TODO
        return 1;
    }

    public async Task<SubmissionResponseModel> GetSubmissionByIdAsync(int id)
    {
        // TODO
        return new SubmissionResponseModel();
    }

    public async Task<IEnumerable<SubmissionResponseModel>> GetAllSubmissionAsync()
    {
        // TODO
        return  new List<SubmissionResponseModel>();
    }
}
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.Infrastructure.Helpper;

public static class ModelMapper
{
    public static CandidateResponseModel ToCandidateResponseModel(this Candidate candidate)
    {
        return new CandidateResponseModel
        {
            Id = candidate.Id,
            FirstName = candidate.FirstName,
            LastName = candidate.LastName,
            Email = candidate.Email,
            ResumeURL = candidate.ResumeURL
        };
    }
    
}
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

    public static SubmissionResponseModel ToSubmissionResponseModel(this Submission submission)
    {
        return new SubmissionResponseModel
        {
            CandidateId = submission.CandidateId,
            ConfirmedOn = submission.ConfirmedOn,
            SubmissionId = submission.SubmissionId,
            SubmittedOn = submission.SubmittedOn,
            SubmissionStatusCode = submission.SubmissionStatusCode,
            RejectedOn = submission.RejectedOn
        };
    }

    public static SubmissionStatusResponseModel ToSubmissionStatusResponseModel(this SubmissionStatus submissionStatus)
    {
        return new SubmissionStatusResponseModel
        {
            LookUpCode = submissionStatus.LookUpCode,
            Description = submissionStatus.Description
        };
    }

    public static JobRequirementResponseModel ToJobRequirementResponseModel(this JobRequirement jobRequirement)
    {
        return new JobRequirementResponseModel
        {
            JobRequirementId = jobRequirement.JobRequirementId,
            Description = jobRequirement.Description,
            Title = jobRequirement.Title,
            ClosedOn = jobRequirement.ClosedOn,
            ClosedReason = jobRequirement.ClosedReason,
            HiringManagerId = jobRequirement.HiringManagerId,
            HiringManagerName = jobRequirement.HiringManagerName,
            StartDate = jobRequirement.StartDate,
            NumberOfPositions = jobRequirement.NumberOfPositions,
            CreatOn = jobRequirement.CreatOn,
            IsActive = jobRequirement.IsActive
        };
    }
    
}
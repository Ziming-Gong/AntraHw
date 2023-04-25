namespace Recruiting.ApplicationCore.Models;

public class SubmissionRequestModel
{
    public int SubmissionId { get; set; } // PK
    public int JobRequirementId { get; set; } // FK JobRequirment
    public int CandidateId { get; set; } // FK: Candidate
    public DateTime SubmittedOn { get; set; }
    public int SubmissionStatusCode { get; set; } // FK: SubmissionStatus
    public DateTime ConfirmedOn { get; set; }
    public DateTime RejectedOn { get; set; }
}
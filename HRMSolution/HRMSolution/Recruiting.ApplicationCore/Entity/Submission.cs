namespace Recruiting.ApplicationCore.Entity;

public class Submission
{
    public int SubmissionId { get; set; }
    
    public int JobRequirementId { get; set; }
    
    public int CandidateId { get; set; }
    
    public DateTime SubmittedOn { get; set; }
    
    public int SubmissionStatusCode { get; set; }
    
    public DateTime ConfirmedOn { get; set; }
    
    public DateTime RejectedOn { get; set; }
    
    
}
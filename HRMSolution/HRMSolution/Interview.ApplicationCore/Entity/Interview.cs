namespace Interview.ApplicationCore.Entity;

public class Interview
{
    public int InterviewId { get; set; }
    public int RecruiterId { get; set; }
    public int SubmissionId { get; set; }
    public int InterviewTypeCode { get; set; }
    public int IntegerRound { get; set; }
    public DateTime ScheduleOn { get; set; }
    public int InterviewerId { get; set; }
    public int FeedbackId { get; set; }
    
    
   
    
    public InterviewType InterviewType { get; set; }
    public Interviewer Interviewer { get; set; }
    public InterviewFeedback InterviewFeedback { get; set; }
    public Recruiter Recruiter { get; set; }
    
    
}
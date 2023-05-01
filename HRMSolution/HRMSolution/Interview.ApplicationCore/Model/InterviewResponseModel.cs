namespace Interview.ApplicationCore.Model;

public class InterviewResponseModel
{
    public int InterviewId { get; set; }
    public int RecruiterId { get; set; }
    public int SubmissionId { get; set; }
    public int InterviewTypeCode { get; set; }
    public int IntegerRound { get; set; }
    public DateTime ScheduleOn { get; set; }
    public int InterviewerId { get; set; }
    public int FeedbackId { get; set; }
}
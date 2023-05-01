namespace Interview.ApplicationCore.Model;

public class InterviewFeedbackRequestModel
{
    public int InterviewFeedbackId { get; set; }
    public int Rating { get; set; }
    public string? Comment { get; set; } 
}
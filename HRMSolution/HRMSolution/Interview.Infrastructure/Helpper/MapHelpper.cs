using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Model;

namespace Interview.Infrastructure.Helpper;

public static class MapHelpper
{
    public static RecruiterResponseModel ToResponseModel(this Recruiter recruiter)
    {
        return new RecruiterResponseModel
        {
            RecruiterId = recruiter.RecruiterId,
            FirstName = recruiter.FirstName,
            LastName = recruiter.LastName,
            EmployeeId = recruiter.EmployeeId
        };
    }

    public static InterviewResponseModel ToInterviewResponseModel(this ApplicationCore.Entity.Interview interview)
    {
        return new InterviewResponseModel
        {
            InterviewerId = interview.InterviewerId,
            RecruiterId = interview.RecruiterId,
            SubmissionId = interview.SubmissionId,
            InterviewTypeCode = interview.InterviewTypeCode,
            IntegerRound = interview.IntegerRound,
            ScheduleOn = interview.ScheduleOn,
            FeedbackId = interview.FeedbackId
        };
    }

    public static InterviewTypeResponseModel ToInterviewTypeResponseMode(
        this  InterviewType interviewType)
    {
        return new InterviewTypeResponseModel()
        {
            LookUpCode = interviewType.LookUpCode,
            Description = interviewType.Description
        };
    }

    public static InterviewFeedbackResponseModel ToInterviewFeedbackResponseModel(
        this InterviewFeedback interviewFeedback)
    {
        return new InterviewFeedbackResponseModel
        {
            Comment = interviewFeedback.Comment,
            InterviewFeedbackId = interviewFeedback.InterviewFeedbackId,
            Rating = interviewFeedback.Rating
        };
    }

    public static InterviewerResponseModel ToInterviewerResponseModel(this Interviewer interviewer)
    {
        return new InterviewerResponseModel
        {
            EmployeeId = interviewer.EmployeeId,
            FirstName = interviewer.FirstName,
            InterviewerId = interviewer.InterviewerId,
            LastName = interviewer.LastName
        };
    }
    
    
    
    
}
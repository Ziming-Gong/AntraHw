using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Exceptions;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Helpper;
using Microsoft.EntityFrameworkCore.Query.Internal;
// using Interview = Interview.ApplicationCore.Entity.Interview;

namespace Interview.Infrastructure.Service;

public class InterviewService : IInterviewService
{
    private readonly IInterviewRepository _interviewRepository;

    public InterviewService(IInterviewRepository interviewRepository)
    {
        _interviewRepository = interviewRepository;
    }
    public async Task<int> InsertAsync(InterviewRequestModel model)
    {
        var exist = await _interviewRepository.GetByIdAsync(model.InterviewerId);
        if (exist != null)
        {
            throw new HasExistException("Interview", "Id", model.InterviewerId);
        }

        ApplicationCore.Entity.Interview interview = new ApplicationCore.Entity.Interview();
        interview.InterviewId = model.InterviewId;
        interview.RecruiterId = model.RecruiterId;
        interview.SubmissionId = model.SubmissionId;
        interview.InterviewTypeCode = model.InterviewTypeCode;
        interview.IntegerRound = model.IntegerRound;
        interview.ScheduleOn = model.ScheduleOn;
        interview.InterviewerId = model.InterviewerId;
        interview.FeedbackId = model.FeedbackId;
        return await _interviewRepository.InsertAsync(interview);
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _interviewRepository.DeleteById(id);
    }

    public async Task<int> UpdateAsync(InterviewRequestModel model)
    {
        var exist = await _interviewRepository.GetByIdAsync(model.InterviewerId);
        if (exist == null)
        {
            throw new NotFoundException("Interview", "Id", model.InterviewerId);
        }

        ApplicationCore.Entity.Interview interview = new ApplicationCore.Entity.Interview();
        interview.InterviewId = model.InterviewId;
        interview.RecruiterId = model.RecruiterId;
        interview.SubmissionId = model.SubmissionId;
        interview.InterviewTypeCode = model.InterviewTypeCode;
        interview.IntegerRound = model.IntegerRound;
        interview.ScheduleOn = model.ScheduleOn;
        interview.InterviewerId = model.InterviewerId;
        interview.FeedbackId = model.FeedbackId;
        return await _interviewRepository.UpdateAsync(interview);    
    }

    public async Task<InterviewResponseModel> GetByIdAsync(int id)
    {
        var exist = await _interviewRepository.GetByIdAsync(id);
        if (exist != null)
        {
            var response = exist.ToInterviewResponseModel();
            return response;
        }
        else
        {
            throw new NotFoundException("Interview", "Id", id);
        }
    }

    public async Task<IEnumerable<InterviewResponseModel>> GetAllAsync()
    {
        var res = await _interviewRepository.GetAllAsync();
        var response = res.Select(x => x.ToInterviewResponseModel());
        return response;
    }
}
using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Exceptions;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Helpper;

namespace Interview.Infrastructure.Service;

public class InterviewFeedbackService : IInterviewFeedBackService
{
    private readonly IInterviewFeedbackRepository _interviewFeedbackRepository;

    public InterviewFeedbackService(IInterviewFeedbackRepository interviewFeedbackRepository)
    {
        _interviewFeedbackRepository = interviewFeedbackRepository;
    }
    public async Task<int> InsertAsync(InterviewFeedbackRequestModel model)
    {
        InterviewFeedback interviewFeedback = new InterviewFeedback();
        interviewFeedback.InterviewFeedbackId = model.InterviewFeedbackId;
        interviewFeedback.Comment = model.Comment;
        interviewFeedback.Rating = model.Rating;
        return await _interviewFeedbackRepository.InsertAsync(interviewFeedback);
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _interviewFeedbackRepository.DeleteById(id);
    }

    public async Task<int> UpdateAsync(InterviewFeedbackRequestModel model)
    {
        var exist = _interviewFeedbackRepository.GetByIdAsync(model.InterviewFeedbackId);
        if (exist == null)
        {
            throw new NotFoundException("Interview Feedback", "id", model.InterviewFeedbackId);
        }
        InterviewFeedback interviewFeedback = new InterviewFeedback();
        interviewFeedback.InterviewFeedbackId = model.InterviewFeedbackId;
        interviewFeedback.Comment = model.Comment;
        interviewFeedback.Rating = model.Rating;
        return await _interviewFeedbackRepository.UpdateAsync(interviewFeedback);
    }

    public async Task<InterviewFeedbackResponseModel> GetByIdAsync(int id)
    {
        var res = await _interviewFeedbackRepository.GetByIdAsync(id);
        if (res != null)
        {
            return res.ToInterviewFeedbackResponseModel();
        }
        else
        {
            throw new NotFoundException("Interview Feedback", "id", id);
        }
    }

    public async Task<IEnumerable<InterviewFeedbackResponseModel>> GetAllAsync()
    {
        var res = await _interviewFeedbackRepository.GetAllAsync();
        var response = res.Select(x => x.ToInterviewFeedbackResponseModel());
        return response;
    }
}
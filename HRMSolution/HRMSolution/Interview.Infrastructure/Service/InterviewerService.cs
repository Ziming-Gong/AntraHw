using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Exceptions;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Helpper;

namespace Interview.Infrastructure.Service;

public class InterviewerService : IInterviewerService
{
    private readonly IInterviewerRepository _interviewerRepository;

    public InterviewerService(IInterviewerRepository interviewerRepository)
    {
        _interviewerRepository = interviewerRepository;
    }
    public async Task<int> InsertAsync(InterviewerRequestModel model)
    {
        var exist = await _interviewerRepository.GetByIdAsync(model.InterviewerId);
        if (exist != null)
        {
            throw new HasExistException("Interviewer", "id", model.InterviewerId);
        }

        Interviewer interviewer = new Interviewer();
        interviewer.InterviewerId = model.InterviewerId;
        interviewer.EmployeeId = model.EmployeeId;
        interviewer.FirstName = model.FirstName;
        interviewer.LastName = model.LastName;
        return await _interviewerRepository.InsertAsync(interviewer);

    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _interviewerRepository.DeleteById(id);
    }

    public async Task<int> UpdateAsync(InterviewerRequestModel model)
    {
        var exist = await _interviewerRepository.GetByIdAsync(model.InterviewerId);
        if (exist == null)
        {
            throw new NotFoundException("Interviewer", "id", model.InterviewerId);
            
        }

        Interviewer interviewer = new Interviewer();
        interviewer.InterviewerId = model.InterviewerId;
        interviewer.EmployeeId = model.EmployeeId;
        interviewer.FirstName = model.FirstName;
        interviewer.LastName = model.LastName;
        return await _interviewerRepository.UpdateAsync(interviewer); 
    }

    public async Task<InterviewerResponseModel> GetByIdAsync(int id)
    {
        var res = await _interviewerRepository.GetByIdAsync(id);
        if (res != null)
        {
            var response = res.ToInterviewerResponseModel();
            return response;
        }
        else
        {
            throw new NotFoundException("Interviewer", "id", id);
        }
    }

    public async Task<IEnumerable<InterviewerResponseModel>> GetAllAsync()
    {
        var res = await _interviewerRepository.GetAllAsync();
        var response = res.Select(x => x.ToInterviewerResponseModel());
        return response;
    }
}
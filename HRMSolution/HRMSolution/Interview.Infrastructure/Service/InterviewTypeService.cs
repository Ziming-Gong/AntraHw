using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Exceptions;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Helpper;

namespace Interview.Infrastructure.Service;

public class InterviewTypeService: IInterviewTypeService
{
    private readonly IInterviewTypeRepository _interviewTypeRepository;

    public InterviewTypeService(IInterviewTypeRepository interviewTypeRepository)
    {
        _interviewTypeRepository = interviewTypeRepository;
    }

    public async Task<int> InsertAsync(InterviewTypeRequestModel model)
    {
        var exist = await _interviewTypeRepository.GetByIdAsync(model.LookUpCode);
        InterviewType interviewType = new InterviewType();
        interviewType.Description = model.Description;
        return await _interviewTypeRepository.InsertAsync(interviewType);
    }

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _interviewTypeRepository.DeleteById(id);
    }

    public async Task<int> UpdateAsync(InterviewTypeRequestModel model)
    {
        var exist = await _interviewTypeRepository.GetByIdAsync(model.LookUpCode);
        if (exist == null)
        {
            throw new NotFoundException("InterviewType", "LookUpCode", model.LookUpCode);
        }

        InterviewType interviewType = new InterviewType();
        interviewType.LookUpCode = model.LookUpCode;
        interviewType.Description = model.Description;
        return await _interviewTypeRepository.UpdateAsync(interviewType);
    }

    public async Task<InterviewTypeResponseModel> GetByIdAsync(int id)
    {
        var res = await _interviewTypeRepository.GetByIdAsync(id);
        if (res != null)
        {
            var response = res.ToInterviewTypeResponseMode();
            return response;
        }

        throw new Exception("Oops!");
    }

    public async Task<IEnumerable<InterviewTypeResponseModel>> GetAllAsync()
    {
        var res = await _interviewTypeRepository.GetAllAsync();
        var response = res.Select(x => x.ToInterviewTypeResponseMode());
        return response;
    }
}
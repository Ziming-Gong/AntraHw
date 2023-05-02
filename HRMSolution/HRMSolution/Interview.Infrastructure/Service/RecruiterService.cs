using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Exceptions;
using Interview.ApplicationCore.Model;
using Interview.Infrastructure.Helpper;
using Interview.Infrastructure.Repositories;

namespace Interview.Infrastructure.Service;

public class RecruiterService : IRecruiterService
{
    private readonly IRecruiterRepository _recruiterRepository;
    public RecruiterService(IRecruiterRepository recruiterRepository)  
    {
        _recruiterRepository = recruiterRepository;
    }

    

    public async Task<int> DeleteByIdAsync(int id)
    {
        return await _recruiterRepository.DeleteById(id);
    }

    public async Task<int> UpdateAsync(RecruiterRequestModel model)
    {
        var exist = await _recruiterRepository.GetByIdAsync(model.RecruiterId);
        if (exist == null)
        {
            throw new NotFoundException("Recruiter", "Id", model.RecruiterId);
        }

        Recruiter recruiter = new Recruiter();
        if (model != null)
        {
            recruiter.RecruiterId = model.RecruiterId;
            recruiter.EmployeeId = model.EmployeeId;
            recruiter.FirstName = model.FirstName;
            recruiter.LastName = model.LastName;
            return await _recruiterRepository.UpdateAsync(recruiter);
        }
        else
        {
            return -1;
        }
    }

    public async Task<RecruiterResponseModel> GetByIdAsync(int id)
    {
        var res = await _recruiterRepository.GetByIdAsync(id);
        if (res != null)
        {
            var response = res.ToResponseModel();
            return response;
        }
        else
        {
            throw new Exception("This Recruiter Not Found");
        }
    }


    public async Task<int> InsertAsync(RecruiterRequestModel model)
    {
        var exist = await _recruiterRepository.GetByIdAsync(model.RecruiterId);
        if (exist != null)
        {
            throw new HasExistException("Recruiter", "id", model.RecruiterId);
        }
        Recruiter recruiter = new Recruiter
        {
            RecruiterId = model.RecruiterId,
            FirstName = model.FirstName,
            LastName = model.LastName,
            EmployeeId = model.EmployeeId
        };
        var res = await _recruiterRepository.InsertAsync(recruiter);
        return res;
    }

    public async Task<IEnumerable<RecruiterResponseModel>> GetAllAsync()
    {
        var recruiters = await _recruiterRepository.GetAllAsync();
        var response = recruiters.Select(x => x.ToResponseModel());
        return response;
    }
}
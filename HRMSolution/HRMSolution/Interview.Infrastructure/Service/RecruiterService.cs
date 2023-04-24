using Interview.ApplicationCore.Constracts.Repositories;
using Interview.ApplicationCore.Constracts.Services;
using Interview.ApplicationCore.Entity;
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

    public async Task<RecruiterResponseModel> GetById(int id)
    {
        var res = await _recruiterRepository.GetByIdAsync(id);
        return MapHelpper.ToResponseModel(res);
    }

    public async Task<int> AddRecruiter(RecruiterRequestModel model)
    {
        Recruiter recruiter = new Recruiter
        {
            RecruiterId = model.RecruiterId,
            EmployeeId = model.EmployeeId,
            FirstName = model.FirstName,
            LastName = model.LastName
        };
        var res = await _recruiterRepository.InsertAsync(recruiter);
        return res;
    }

    public async Task<IEnumerable<RecruiterResponseModel>> GetAll()
    {
        var recruiters = await _recruiterRepository.GetAllAsync();
        var response = recruiters.Select(x => x.ToResponseModel());
        return response;
    }
}
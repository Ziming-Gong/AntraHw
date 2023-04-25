using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;
using Recruiting.Infrastructure.Helpper;

namespace Recruiting.Infrastructure.Service;

public class SubmissionStatusService : ISubmissionStatusService
{
    private readonly ISubmissionStatusRepository _submissionStatusRepository;

    public SubmissionStatusService(ISubmissionStatusRepository submissionStatusRepository)
    {
        _submissionStatusRepository = submissionStatusRepository;
    }
    public async Task<int> AddStatusAsync(SubmissionStatusRequestModel model)
    {
        // TODO if exist
        SubmissionStatus submissionStatus = new SubmissionStatus();
        if (model != null)
        {
            submissionStatus.Description = model.Description;
            await _submissionStatusRepository.InsertAsync(submissionStatus);
            return 1;
        }
        else
        {
            return 0;
        }
    }

    public async Task<int> UpdateStatusAsync(SubmissionStatusRequestModel model)
    {
       //TODO if exist
       SubmissionStatus submissionStatus = new SubmissionStatus();
       if (model != null)
       {
           submissionStatus.Description = model.Description;
           await _submissionStatusRepository.UpdateAsync(submissionStatus);
           return 1;
       }
       else
       {
           return 0;
       } 
    }

    public async Task<int> DeleteStatusAsync(int id)
    {
        return await _submissionStatusRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<SubmissionStatusResponseModel>> GetAllStatus()
    {
        var status = await _submissionStatusRepository.GetAllAsync();
        var res = status.Select(x => x.ToSubmissionStatusResponseModel());
        return res;
    }

    public async Task<SubmissionStatusResponseModel> GetStatusByIdAsync(int id)
    {
        var res = await _submissionStatusRepository.GetByIdAsync(id);
        if (res != null)
        {
            return res.ToSubmissionStatusResponseModel();
        }
        else
        {
            throw new Exception("this not exist");
        }
    }
}
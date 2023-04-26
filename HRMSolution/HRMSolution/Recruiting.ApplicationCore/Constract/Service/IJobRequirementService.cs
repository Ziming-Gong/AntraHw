using Recruiting.ApplicationCore.Models;

namespace Recruiting.ApplicationCore.Constract.Service;

public interface IJobRequirementService
{
    Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);
    Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);
    Task<int> DeleteJobRequirementAsync(int id);
    Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements();
    Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id);
}
using Recruiting.ApplicationCore.Constract.Repository;
using Recruiting.ApplicationCore.Constract.Service;
using Recruiting.ApplicationCore.Entity;
using Recruiting.ApplicationCore.Models;

namespace Recruiting.Infrastructure.Service;

public class JobRequirementsService : IJobRequirementService
{

    private readonly IJobRequirementRepository _jobRequirementRepository;

    public JobRequirementsService(IJobRequirementRepository jobRequirementRepository)
    {
        _jobRequirementRepository = jobRequirementRepository;
    }
    public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
    {
        JobRequirement jobRequirement = new JobRequirement();
        if (model != null)
        {
            jobRequirement.JobRequirementId = model.JobRequirementId;
            jobRequirement.Description = model.Description;
            jobRequirement.Title = model.Title;
            jobRequirement.ClosedOn = model.ClosedOn;
            jobRequirement.ClosedReason = model.ClosedReason;
            jobRequirement.HiringManagerId = model.HiringManagerId;
            jobRequirement.HiringManagerName = model.HiringManagerName;
            jobRequirement.StartDate = model.StartDate;
            jobRequirement.Submissions = new List<Submission>();
            jobRequirement.EmployeeRequirementTypes = new List<EmployeeRequirementType>();
            jobRequirement.NumberOfPositions = model.NumberOfPositions;
            jobRequirement.CreatOn = model.CreatOn;
            jobRequirement.IsActive = model.IsActive;
        }

        return await _jobRequirementRepository.InsertAsync(jobRequirement);
    }

    public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
    {
        var exist = _jobRequirementRepository.GetJobRequirementIncludeCategory(x =>
            model.JobRequirementId == x.JobRequirementId);
        if (exist == null)
        {
            throw new Exception("Job Requirement is not exist");
        }
        JobRequirement jobRequirement = new JobRequirement();
        if (model != null)
        {
            jobRequirement.JobRequirementId = model.JobRequirementId;
            jobRequirement.Description = model.Description;
            jobRequirement.Title = model.Title;
            jobRequirement.ClosedOn = model.ClosedOn;
            jobRequirement.ClosedReason = model.ClosedReason;
            jobRequirement.HiringManagerId = model.HiringManagerId;
            jobRequirement.HiringManagerName = model.HiringManagerName;
            jobRequirement.StartDate = model.StartDate;
            jobRequirement.Submissions = new List<Submission>();
            jobRequirement.EmployeeRequirementTypes = new List<EmployeeRequirementType>();
            jobRequirement.NumberOfPositions = model.NumberOfPositions;
            jobRequirement.CreatOn = model.CreatOn;
            jobRequirement.IsActive = model.IsActive;
        }

        return await _jobRequirementRepository.UpdateAsync(jobRequirement);

    }

    public async Task<int> DeleteJobRequirementAsync(int id)
    {
        return await _jobRequirementRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
    {
        var jRTypes = await _jobRequirementRepository.GetAllAsync();
        var response = jRTypes.Select(x => x.ToJobRequirementResponseModel());
        return response;
    }

    public async Task<JobRequirementResponseModel> GetJobRequirementByIdAsync(int id)
    {
        var jR = await _jobRequirementRepository.GetByIdAsync(id);
        if (jR != null)
        {
            var response = jR.ToJobRequirementResponseModel();
            return response;
        }
        else
        {
            throw new NotFoundException("JobRequirement", id);
        }
    }
}
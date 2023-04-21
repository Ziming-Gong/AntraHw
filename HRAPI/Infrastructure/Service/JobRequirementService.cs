using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Models;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Infrastructure.Repositories;
using Infrastructure.Helper;
using ApplicationCore.Exceptions;

namespace Infrastructure.Service
{
	public class JobRequirementService : IJobRequirementService
	{

        private readonly IJobRequirementRepository _jobRequirementRepository;
		public JobRequirementService(IJobRequirementRepository jobRequirementRepository)
		{
            _jobRequirementRepository = jobRequirementRepository;
		}

        public async Task<int> AddJobRequirementAsync(JobRequirementRequestModel model)
        {
            JobRequirement jobRequirement = new JobRequirement();
            if(model != null)
            {
                jobRequirement.NumberOfPosition = model.NumberOfPosition;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                jobRequirement.Submissions = new List<Submission>();
                jobRequirement.EmployeeRequirementType = new List<EmployeeRequirementType>();
            }
            return await _jobRequirementRepository.InsertAsync(jobRequirement);
        }

        public Task<int> DeleteJobRequirementAsync(int id)
        {
            return _jobRequirementRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements()
        {
            var jrs = await _jobRequirementRepository.GetAllAsync();
            
            var response = jrs.Select(x => x.ToJobRequirementResponseModel());
            return response;
        }

        public async Task<JobRequirementResponseModel> GetJobRequirementById(int id)
        {
            var existJR = await _jobRequirementRepository.GetByIdAsync(id);
            if (existJR == null)
            {
                throw new NotFoundException("JobRequirement", id);
            }
            else
            {
                return existJR.ToJobRequirementResponseModel();

            }
        }

        public async Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model)
        {
            var existingJobRequrement = await _jobRequirementRepository.GetJobRequirementsIncludingCategory(x => model.Id == x.Id);
            if(existingJobRequrement == null)
            {
                throw new Exception("JobRequirement");
            }
            JobRequirement jobRequirement = new JobRequirement();
            if(model != null)
            {
                jobRequirement.NumberOfPosition = model.NumberOfPosition;
                jobRequirement.Title = model.Title;
                jobRequirement.Description = model.Description;
                jobRequirement.HiringManagerId = model.HiringManagerId;
                jobRequirement.StartDate = model.StartDate;
                jobRequirement.IsActive = model.IsActive;
                jobRequirement.ClosedOn = model.ClosedOn;
                jobRequirement.ClosedReason = model.ClosedReason;
                jobRequirement.CreatedOn = model.CreatedOn;
                jobRequirement.Submissions = new List<Submission>();
                jobRequirement.EmployeeRequirementType = new List<EmployeeRequirementType>();
                return await _jobRequirementRepository.UpdateAsync(jobRequirement);
            }
            else
            {
                return -1;
            }
        }
    }
}


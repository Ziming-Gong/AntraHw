using System;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
	public interface IJobRequirementService
	{
		public Task<int> AddJobRequirementAsync(JobRequirementRequestModel model);

		public Task<int> UpdateJobRequirementAsync(JobRequirementRequestModel model);

		public Task<int> DeleteJobRequirementAsync(int id);

		public Task<IEnumerable<JobRequirementResponseModel>> GetAllJobRequirements();

		public Task<JobRequirementResponseModel> GetJobRequirementById(int id);
	}
}


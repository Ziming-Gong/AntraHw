using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;
using Infrastructure.Helper;
using ApplicationCore.Models;
using ApplicationCore.Exceptions;

namespace Infrastructure.Service
{
	public class StatusService : IStatusService
	{
        private readonly IStatusRepository _statusRepository;
        private readonly ISubmissionRepository _submissionRepository;
		public StatusService(IStatusRepository statusRepository, ISubmissionRepository submissionRepository)
		{
			_statusRepository = statusRepository;
            _submissionRepository = submissionRepository;
		}

        public async Task<int> AddStatusAsync(StatusRequestModel model)
        {
            var relevantSubmission = await _submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.CandidateId == model.CandidateId &&
            s.JobRequirementId == model.JobrequirementId, s => s.Status);
            var statusList = relevantSubmission.Status.Count - 1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if(model != null)
            {
                status.SubmissionId = relevantSubmission.Id;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                status.Submission = relevantSubmission;
            }
            return await _statusRepository.InsertAsync(status);
        }

        public async Task<int> DeleteStatusAsnyc(int id)
        {
            return await _statusRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<StatusResponseModel>> GetAllStatus()
        {
            var statuses = await _statusRepository.GetAllAsync();
            var response = statuses.Select(x => x.ToStatusResponseModel());
            return response;
        }

        public async Task<StatusResponseModel> GetStatusByIdAsync(int id)
        {
            var state = await _statusRepository.GetByIdAsync(id);
            if (state != null)
            {
                var response = state.ToStatusResponseModel();
                return response;
            }
            else
            {
                throw new NotFoundException("Status", id);
            }
        }

        public async Task<int> UpdateStatusAsync(StatusRequestModel model)
        {
            var relevantSubmission = await _submissionRepository.FirstOrDefaultWithIncludesAsync(s => s.Id == model.SubmissionId, s => s.Status);
            var statusList = relevantSubmission.Status.Count - 1;
            var existingStatus = relevantSubmission.Status.FirstOrDefault(s => s.Id == relevantSubmission.Status[statusList].Id);
            if (existingStatus != null && existingStatus.State == model.State)
            {
                throw new Exception("Status is not changing");
            }
            Status status = new Status();
            if (model != null)
            {
                status.Id = model.Id;
                status.SubmissionId = model.SubmissionId;
                status.State = model.State;
                status.ChangedOn = DateTime.Now;
                status.StatusMessage = model.StatusMessage;
                return await _statusRepository.UpdateAsync(status);
            }
            else
            {
                return -1;
            }

        }
    }
}


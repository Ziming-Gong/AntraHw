using Recruiting.ApplicationCore.Entity;

namespace Recruiting.ApplicationCore.Constract.Repository;

public interface ISubmissionStatusRepository : IRepositoryAsync<SubmissionStatus>
{
    // Task<IEnumerable<SubmissionStatus>> GetStatusByStatus(string status);
}
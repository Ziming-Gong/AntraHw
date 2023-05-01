using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Entity;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repositories;

public class EmployeeStatusRepository : BaseRepository<EmployeeStatus>, IEmployeeStatusRepository
{
    public EmployeeStatusRepository(OnboardingDbContext context) : base(context)
    {
    }
}
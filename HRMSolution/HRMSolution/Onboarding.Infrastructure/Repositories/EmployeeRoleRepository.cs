using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Entity;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repositories;

public class EmployeeRoleRepository : BaseRepository<EmployeeRole>, IEmployeeRoleRepository
{
    public EmployeeRoleRepository(OnboardingDbContext context) : base(context)
    {

    }
}
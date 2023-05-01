using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Entity;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repositories;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(OnboardingDbContext context) : base(context)
    {
    }
}
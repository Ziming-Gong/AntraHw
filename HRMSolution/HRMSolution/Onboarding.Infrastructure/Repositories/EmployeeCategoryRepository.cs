using Onboarding.ApplicationCore.Constracts.Repositories;
using Onboarding.ApplicationCore.Entity;
using Onboarding.Infrastructure.Data;

namespace Onboarding.Infrastructure.Repositories;

public class EmployeeCategoryRepository : BaseRepository<EmployeeCategory>, IEmployeeCategoryRepository
{
    public EmployeeCategoryRepository(OnboardingDbContext context) : base(context)
    {
    }
}
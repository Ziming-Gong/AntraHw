using Interview.ApplicationCore.Entity;
using Interview.ApplicationCore.Model;

namespace Interview.Infrastructure.Helpper;

public static class MapHelpper
{
    public static RecruiterResponseModel ToResponseModel(this Recruiter recruiter)
    {
        return new RecruiterResponseModel
        {
            RecruiterId = recruiter.RecruiterId,
            FirstName = recruiter.FirstName,
            LastName = recruiter.LastName,
            EmployeeId = recruiter.EmployeeId
        };
    }
    
}
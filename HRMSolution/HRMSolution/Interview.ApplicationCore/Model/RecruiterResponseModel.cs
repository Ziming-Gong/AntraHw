using System.ComponentModel.DataAnnotations;

namespace Interview.ApplicationCore.Model;

public class RecruiterResponseModel
{
    public int RecruiterId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int EmployeeId { get; set; }
}
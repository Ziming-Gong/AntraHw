using System.ComponentModel.DataAnnotations;

namespace Interview.ApplicationCore.Model;

public class RecruiterResponseModel
{
    public int RecruiterId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    public int EmployeeId { get; set; }
}
namespace Onboarding.ApplicationCore.Model;

public class EmployeeResponseModel
{
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName{ get; set; }
    public string? MiddleName{ get; set; }
    public string SSN { get; set; }
    public DateTime HireDate { get; set; }
    public DateTime EndDate { get; set; }
    public int EmployeeCategoryCode { get; set; }
    public int EmployeeStatusCode { get; set; }
    public string? Address { get; set; }
    public string Email { get; set; }
    public int EmployeeRoleId { get; set; }
}
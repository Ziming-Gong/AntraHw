using System.ComponentModel.DataAnnotations;

namespace Recruiting.ApplicationCore.Entity;

public class JobCategory
{
    public int Id { get; set; }
    [Required]
    [StringLength(128)]
    public string Name { get; set; }
    public IEnumerable<JobRequirement> JobRequirements { get; set; }
}
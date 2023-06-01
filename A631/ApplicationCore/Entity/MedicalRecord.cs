using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApplicationCore.Entity;

public class MedicalRecord
{
    [Key]
    public Guid RecordId { get; set; }
    [Required]
    public string Description { get; set; }
    [Required]
    public Guid PatientId { get; set; }
    public Patient Patient { get; set; }
    
}
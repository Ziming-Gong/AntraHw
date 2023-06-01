using System.ComponentModel.DataAnnotations;
using ApplicationCore.Attributes;

namespace ApplicationCore.Entity;

public class Patient
{
   [Key]
   public Guid Id { get; set; }
   [Required]
   public string FirstName { get; set; }
   [Required]
   public string LastName { get; set; }
   public string? MiddleName { get; set; }
   [Required]
   public string PhoneNumber { get; set; }

   public ICollection<MedicalRecord> MedicalRecords { get; set; }
   
   
}
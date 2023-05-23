using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Recruiting.ApplicationCore.Entity
{

    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string FirstName { get; set; }

        [Required]
        [Column(TypeName = "varchar(30)")]
        public string LastName { get; set; }

        [Required]
        [Column(TypeName = "varchar(150)")]
        public string Email { get; set; }

        [Required]
        [Column(TypeName = "varchar(300)")]
        public string ResumeURL { get; set; }
        
        public IEnumerable<Submission> Submissions { get; set; } 


    }
}
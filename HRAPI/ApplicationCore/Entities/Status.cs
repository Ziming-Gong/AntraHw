using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
	public class Status
	{
        [Key]
        public int Id { get; set; }

        public string State { get; set; }

        public DateTime? ChangedOn { get; set; }

        public string StatusMessage { get; set; }

        public int SubmissionId { get; set; }

        //naviagational property
        public Submission Submission { get; set; }
    }
}


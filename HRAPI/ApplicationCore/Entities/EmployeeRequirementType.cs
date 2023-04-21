using System;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities;
namespace ApplicationCore.Entities
{
	public class EmployeeRequirementType 
	{
        [Key]
        public int JobRequirementId { get; set; }

        public int EmployeeTypeId { get; set; }

        public JobRequirement JobRequirement { get; set; }

        public EmployeeType EmployeeType { get; set; }
    }
}


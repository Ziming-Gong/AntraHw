using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities
{
	public class EmployeeType
	{
        [Key]
        public int Id { get; set; }

        public string TypeName { get; set; }

        public List<EmployeeRequirementType> EmployeeRequirementTypes { get; set; }
    }
}


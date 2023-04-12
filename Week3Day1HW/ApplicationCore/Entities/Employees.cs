using System;
namespace ApplicationCore.Entities
{
	public class Employees
	{
		public int Id { get; set; }

		public string FirstName { get; set; }

		public string LastName { get; set; }

		public decimal Salary { get; set; }

		public int DeptId { get; set; }

		public Departments Department { get; set; }




		public Employees()
		{
		}
	}
}


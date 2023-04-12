using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
	public interface IEmployeeService
	{
		void AddEmployee();
		void UpdateEmployee();
		Employees GetEmployeeById();
		IEnumerable<Employees> GetAllEmployees();
		void DeleteEmployee();
	}
}


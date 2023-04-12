using System;
using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Services
{
	public interface IDepartmentService
	{
		void AddDepartment();

		void DeleteDepartment();

		void getAllDepartment();

		Departments GetDepartmentsById();

		void UpdateDepartment();
	}
}


using System;
using ApplicationCore.Models;
namespace ApplicationCore.Contracts.Services
{
	public interface IEmployeeTypeServices
	{
		public Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model);

		public Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model);

		public Task<int> DeleteEmployeeTypeAsync(int id);

		public Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypeAsync();

		public Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id);

	}
}


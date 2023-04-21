using System;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models;
using Infrastructure.Helper;



namespace Infrastructure.Service
{
    public class EmployeeTypeService : IEmployeeTypeServices
    {
        IEmployeeTypeRepository employeeTypeRepository;
        public EmployeeTypeService(IEmployeeTypeRepository _employeeTypes)
        {
            employeeTypeRepository = _employeeTypes;
        }
        public async Task<int> AddEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existEmployeeType = employeeTypeRepository.GetEmployeeTypeByTypeName(model.TypeName);
            if(existEmployeeType != null)
            {
                throw new Exception("Employee Type exist");
            }

            EmployeeType employeeType = new EmployeeType();
            if(model != null)
            {
                employeeType.TypeName = model.TypeName.ToLower();             
            }
            return await employeeTypeRepository.InsertAsync(employeeType);
            
        }

        public async Task<int> DeleteEmployeeTypeAsync(int id)
        {
            return await employeeTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EmployeeTypeResponseModel>> GetAllEmployeeTypeAsync()
        {
            var employeeTypes = await employeeTypeRepository.GetAllAsync();
            var list = employeeTypes.Select(x => x.ToEmployeeTypeResponseModel());
            return list;
        }

        
        public async Task<EmployeeTypeResponseModel> GetEmployeeTypeByIdAsync(int id)
        {
            var employeeType = await employeeTypeRepository.GetByIdAsync(id);
            if(employeeType != null)
            {
                return employeeType.ToEmployeeTypeResponseModel();
            }
            else
            {
                throw new NotFoundException("EmployeeType", id);
            }
        }

        public async Task<int> UpdateEmployeeTypeAsync(EmployeeTypeRequestModel model)
        {
            var existEmpType = await employeeTypeRepository.GetByIdAsync(model.Id);
            if(existEmpType == null)
            {
                throw new Exception("Employee Type is not exist");
            }
            EmployeeType empType = new EmployeeType();
            if(model != null)
            {
                empType.TypeName = model.TypeName.ToLower();
                return await employeeTypeRepository.UpdateAsync(empType);
            }
            else
            {
                return -1;
            }
            

        }
    }
}


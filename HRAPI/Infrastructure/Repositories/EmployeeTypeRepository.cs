using System;
using Infrastructure.Data;
using ApplicationCore.Entities;
using ApplicationCore.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class EmployeeTypeRepository : BaseRepository<EmployeeType>, IEmployeeTypeRepository
	{
		public EmployeeTypeRepository(RecruitingDbContext context) : base(context)
        {
        }
        public async Task<EmployeeType> GetEmployeeTypeByTypeName(string typeName)
        {
            return await _dbContext.EmployeeTypes.Where(x => x.TypeName == typeName.ToLower()).FirstOrDefaultAsync();
        }
    }
}


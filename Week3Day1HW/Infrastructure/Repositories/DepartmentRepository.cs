using System;
using System.Data;
using System.Data.SqlClient;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
	public class DepartmentRepository : IRepository<Departments>
    {
        private readonly DapperDbContext _dbContext;

		public DepartmentRepository() 
		{
            _dbContext = new DapperDbContext();
		}

        public int DeleteById(int id)
        {
            using( IDbConnection conn = _dbContext.GetConnection()){
                int res = 0;
                try
                {
                    res = conn.Execute("Delete from Departments Where Id = @Id", new { Id = id });
                }
                catch (SqlException)
                {
                    Console.WriteLine("Please deleted the employee in this Department first!");
                }
                return res;
            }

        }

        public IEnumerable<Departments> GetAll()
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Departments>("Select Id, DeptName, Location From Departments");
            }
        }

        public Departments GetById(int id)
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Departments>("Select Id, DeptName, Location From Departments Where Id = @Id", new { Id = id });
            }
        }

        public int Insert(Departments obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Insert into Departments values (@DeptName, @Location)", obj);
            }
        }

        public int Update(Departments obj)
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Update Departments set DeptNAme = @DeptName, Location = @Location Where Id = @Id", obj);
            }
        }
    }
}


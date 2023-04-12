using System;
using System.Data;
using System.Data.SqlClient;
using ApplicationCore.Contracts.Repositories;
using ApplicationCore.Entities;
using Dapper;
using Infrastructure.Data;

namespace Infrastructure.Repositories
{
    public class EmployeeRepository : IRepository<Employees>
    {
        public EmployeeRepository()
        {
            _dbContext = new DapperDbContext();
        }
        private readonly DapperDbContext _dbContext;

        public int DeleteById(int id)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Execute("Delete from Employees where Id = @Id", new { Id = id });
            }
        }

        public IEnumerable<Employees> GetAll()
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.Query<Employees>("Select * from Employees");
            }
        }

        public Employees GetById(int id)
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                return conn.QuerySingleOrDefault<Employees>("Select * from Employees where Id = @Id", new { Id = id });
            }
        }

        public int Insert(Employees obj) 
        {
            using(IDbConnection conn = _dbContext.GetConnection())
            {
                int res = 0;
                try
                {
                    res = conn.Execute("Insert into Employees values(@FirstName, @LastName, @Salary, @DeptId)", obj);
                }
                catch (SqlException)
                {
                    Console.WriteLine("Oops! Please Check the information of Input!");
                }
                return res;
            }
        }

        public int Update(Employees obj)
        {
            using (IDbConnection conn = _dbContext.GetConnection())
            {
                int res = 0;
                try
                {
                    res = conn.Execute("Update Employees set FirstName = @FirstName, LastName = @LastName, Salary = @Salary, DeptId = @DeptId Where Id = @Id", obj);
                }
                catch (SqlException)
                {
                    Console.WriteLine("Oops! Please Check the information of Input!");
                }
                return res;
                
            }
        }
    }
}

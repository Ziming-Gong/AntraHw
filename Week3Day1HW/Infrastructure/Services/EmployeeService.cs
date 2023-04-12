using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class EmployeeService : IEmployeeService
	{
        EmployeeRepository employeeRepository;

        public EmployeeService()
        {
            employeeRepository = new EmployeeRepository();
        }

        public void AddEmployee()
        {
            try
            {
                Employees e = new Employees();
                Console.Write("Enter FirstName: ");
                e.FirstName = Console.ReadLine();
                Console.Write("Enter LastName: ");
                e.LastName = Console.ReadLine();
                Console.Write("Enter Salary: ");
                e.Salary = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter DeptId: ");
                e.DeptId = Convert.ToInt32(Console.ReadLine());
                int row = employeeRepository.Insert(e);
                if (row > 0)
                {
                    Console.WriteLine("Insert Successfully");
                }
                else
                {
                    Console.WriteLine("Oops!");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please Check the information of Input");
            }

        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            int row = employeeRepository.DeleteById(id);

            if (row > 0)
            {
                Console.WriteLine("Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Oops!");
            }
        }

        public IEnumerable<Employees> GetAllEmployees()
        {
            IEnumerable<Employees> employees = employeeRepository.GetAll();
            foreach(var e in employees)
            {
                Console.WriteLine($"{e.Id} \t {e.FirstName} \t {e.LastName} \t {e.Salary} \t {e.DeptId}");
            }
            return employees;
        }

        public Employees GetEmployeeById()
        {
            Console.Write("Enter Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Employees e = employeeRepository.GetById(id);
            try
            {
                Console.WriteLine($"{e.Id} \t {e.FirstName} \t {e.LastName} \t {e.Salary} \t {e.DeptId}");

            }
            catch (NullReferenceException)
            {
                Console.WriteLine("There is no speific Id");
            }
            return e;
        }

        public void UpdateEmployee()
        {
            try
            {
                Employees e = GetEmployeeById();
                Console.Write("Enter New FirstName: ");
                e.FirstName = Console.ReadLine();
                Console.Write("Enter New LastName: ");
                e.LastName = Console.ReadLine();
                Console.Write("Enter New Salary: ");
                e.Salary = Convert.ToDecimal(Console.ReadLine());
                Console.Write("Enter New DeptId: ");
                e.DeptId = Convert.ToInt32(Console.ReadLine());
                int row = employeeRepository.Update(e);
                if (row > 0)
                {
                    Console.WriteLine("Insert Successfully");
                }
                else
                {
                    Console.WriteLine("Oops!");
                }
            }
            catch (FormatException e)
            {
                Console.WriteLine("Please Check the information of Input");
            }
        }
    }
}


using System;
using ApplicationCore.Contracts.Services;
using ApplicationCore.Entities;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
	public class DepartmentService : IDepartmentService
	{
		DepartmentRepository departmentRepository;

		public DepartmentService()
		{
            departmentRepository = new DepartmentRepository();
        }

        public void AddDepartment()
		{
			Departments d = new Departments();
			Console.Write("Enter name of Department: ");
			d.DeptName = Console.ReadLine();
			Console.Write("Enter Location: ");
			d.Location = Console.ReadLine();

			if(departmentRepository.Insert(d) > 0)
			{
				Console.WriteLine("Successfully Inserted");
			}
			else
			{
				Console.WriteLine("Oops!");
			}
		}

		public void DeleteDepartment()
		{
			Console.Write("the department Id to Delete: ");
			int id = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine(id);
			
			int num = departmentRepository.DeleteById(id);
			if(num > 0)
			{
                Console.WriteLine("Successfully Deleted");
            }
            else
            {
                Console.WriteLine("Oops!");
            }

        }

        public void getAllDepartment()
        {
			IEnumerable<Departments> departments = departmentRepository.GetAll();
			foreach(var dept in departments)
			{
                Console.WriteLine($"{dept.Id} \t {dept.DeptName} \t {dept.Location}");
            }
        }

        public Departments GetDepartmentsById()
        {
			Console.WriteLine("Enter Id: ");
			int id = Convert.ToInt32(Console.ReadLine());
			Departments department = departmentRepository.GetById(id);
			try
			{
                Console.WriteLine($"{department.Id} \t {department.DeptName} \t {department.Location}");

            }catch(NullReferenceException e)
			{
				Console.WriteLine("There is no speific Id");
			}

            return department;
		
        }

        public void UpdateDepartment()
        {
			var old = GetDepartmentsById();
			Console.Write("Enter New DeptName: ");
			old.DeptName = Console.ReadLine();
			Console.Write("Enter New Location: ");
			old.Location = Console.ReadLine();
			departmentRepository.Update(old);
        }
    }

	
}


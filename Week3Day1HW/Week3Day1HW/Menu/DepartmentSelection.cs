using System;
using ApplicationCore.Contracts.Services;
using Infrastructure.Services;

namespace Week3Day1HW.Menu
{
	public class DepartmentSelection
	{
		DepartmentService departmentService;
		public DepartmentSelection()
		{
            departmentService = new DepartmentService();
            Screen();
        }
        public void Screen()
        {
            Console.WriteLine("Department Operations");
            Console.WriteLine("#1 Add Department");
            Console.WriteLine("#2 Delete Department");
            Console.WriteLine("#3 Update Department");
            Console.WriteLine("#4 Get Department By Id");
            Console.WriteLine("#5 Get All Department");
        }

        public int Input()
        {
            Console.WriteLine("Enter the Number of Service");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num < 0 || num > 5)
            {
                Console.WriteLine("Please Enter A Valid Number of Service");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return num;
        }

        public void Run()
        {
            int choice = Input();
            switch (choice)
            {
                case 1:
                    departmentService.AddDepartment();
                    break;
                case 2:
                    departmentService.DeleteDepartment();
                    break;
                case 3:
                    departmentService.UpdateDepartment();
                    break;
                case 4:
                    departmentService.GetDepartmentsById();
                    break;
                case 5:
                    departmentService.getAllDepartment();
                    break;
                default:
                    Console.WriteLine("invalid Number");
                    break;
            }

        }

    }
}


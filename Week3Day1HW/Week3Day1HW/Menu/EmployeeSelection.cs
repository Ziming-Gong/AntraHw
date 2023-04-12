using System;
using Infrastructure.Services;

namespace Week3Day1HW.Menu
{
	public class EmployeeSelection
	{
        EmployeeService employeeService;
		public EmployeeSelection()
		{
            employeeService = new EmployeeService();
            Screen();
		}

        public void Screen()
        {
            Console.WriteLine("Employee Operations");
            Console.WriteLine("#1 Add Employee");
            Console.WriteLine("#2 Delete Employee");
            Console.WriteLine("#3 Update Employee");
            Console.WriteLine("#4 Get Employee By Id");
            Console.WriteLine("#5 Get All Employee");
        }

        public int Input()
        {
            Console.WriteLine("Enter the Number of Service");
            int num = Convert.ToInt32(Console.ReadLine());
            while(num < 0 || num > 5)
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
                    employeeService.AddEmployee();
                    break;
                case 2:
                    employeeService.DeleteEmployee();
                    break;
                case 3:
                    employeeService.UpdateEmployee();
                    break;
                case 4:
                    employeeService.GetEmployeeById();
                    break;
                case 5:
                    employeeService.GetAllEmployees();
                    break;
                default:
                    Console.WriteLine("invalid Number");
                    break;
            }

        }


    }
}


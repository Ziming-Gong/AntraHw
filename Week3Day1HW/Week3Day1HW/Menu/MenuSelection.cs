using System;
namespace Week3Day1HW.Menu
{
	public class MenuSelection
	{
		public MenuSelection()
		{
            Screen();
            
        }

        public void Screen()
        {
            Console.WriteLine("#1 Employee Operations");
            Console.WriteLine("#2 Department Operations");
        }
        public int Input()
        {
            Console.Write("Enter the Operation Number: ");
            int num = Convert.ToInt32(Console.ReadLine());
            while (num != 1 && num != 2)
            {
                Console.Write("Please Enter the Valid Number : ");
                num = Convert.ToInt32(Console.ReadLine());
            }
            return num;
        }
        public void Run()
        {
            bool cont = true;
            while (cont)
            {
                int num = Input();
                if (num == 1)
                {
                    EmployeeSelection es = new EmployeeSelection();
                    while (true)
                    {
                        es.Run();
                        Console.WriteLine("Type 1 if you want to do more work on Department! Type #2 if you want to return to the main Menu!");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (input == 1)
                        {
                            continue;
                        }
                        else if (input == 2)
                        {
                            break;
                        }
                        else
                        {
                            cont = false;
                            break;
                        }
                    }

                }
                else
                {
                    DepartmentSelection ds = new DepartmentSelection();
                    while (true)
                    {
                        ds.Run();
                        Console.WriteLine("Type 1 if you want to do more work on Department! Type #2 if you want to return to the main Menu!");
                        int input = Convert.ToInt32(Console.ReadLine());
                        if (input == 1)
                        {
                            continue;
                        }
                        else if(input == 2)
                        {
                            break;
                        }
                        else
                        {
                            cont = false;
                            break;
                        }
                    }

                }
            }
            
        }
    }
}


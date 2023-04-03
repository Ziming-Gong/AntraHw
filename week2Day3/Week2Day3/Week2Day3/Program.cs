// See https://aka.ms/new-console-template for more information
namespace Week2Day3;

public class Program
{
    public static void Main()
    {
        // test for MyStack
        //MyStack<int> stack = new MyStack<int>();

        //Console.WriteLine(stack.Count());
        //Console.WriteLine(stack.Pop());
        //stack.Push(1);
        //Console.WriteLine(stack.Count());
        //stack.Push(2);
        //Console.WriteLine(stack.Count());
        //stack.Push(3);
        //Console.WriteLine(stack.Count());
        //stack.Push(4);
        //Console.WriteLine(stack.Count());
        //Console.WriteLine("xxxxxxxxxxxx");// 1. 2. 3. 4
        //Console.WriteLine(stack.Pop());// 1. 2. 3.
        //Console.WriteLine(stack.Count());
        //stack.Push(10);// 1. 2. 3. 10
        //Console.WriteLine(stack.Count());
        //Console.WriteLine(stack.Pop());
        //Console.WriteLine(stack.Pop());
        //Console.WriteLine(stack.Pop());
        //Console.WriteLine(stack.Pop());
        //Console.WriteLine(stack.Pop());

        // test for list
        /*
        1. void Add (T element)
        2. T Remove (int index)
        3. bool Contains (T element)
        4. void Clear ()
        5. void InsertAt (T element, int index)
        6. void DeleteAt (int index)
        7. T Find (int index)
        */
        MyList<int> list = new MyList<int>();
        list.print();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        list.Add(5);
        list.print();
        list.DeleteAt(0);
        list.print();
        Console.WriteLine(list.Find(0));
        list.print();
        Console.WriteLine(list.Contains(5));
        Console.WriteLine(list.Contains(10));
        list.InsertAt(10, 1);
        list.print();
        list.Clear();
        list.print();

    }
}


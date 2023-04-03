using System;
namespace Week2Day3
{
	public class MyStack<T>
	{

		List<T> list;

		int size;

		public MyStack()
		{
			list = new List<T>();
			size = 0;

		}

		public int Count()
		{
			return size;

		}

		public T Pop()
		{
			if(size == 0)
			{
				return default(T);
			}

			return list[--size];
		}

		public void Push(T obj)
		{
			list.Insert(size++, obj);
		}


	}
}


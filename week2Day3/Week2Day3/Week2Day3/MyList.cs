using System;
using System.Runtime.ConstrainedExecution;

namespace Week2Day3;

/*
1. void Add (T element)
2. T Remove (int index)
3. bool Contains (T element)
4. void Clear ()
5. void InsertAt (T element, int index)
6. void DeleteAt (int index)
7. T Find (int index)
*/
public class MyList<T>
{
	private MyNode<T> head;
	private int size;
	private MyNode<T> last;
	public MyList()
	{
		head = new MyNode<T>(default(T));
		size = 0;
		last = head;
	}
	public void Add(T element)
	{
		MyNode<T> newNode = new MyNode<T>(element);
		size++;
		newNode.preNode = last;
		last.nextNode = newNode;
		last = last.nextNode;
		
	}

	public T Remove(int index)
	{
		if(index > size - 1)
		{
			//throw new Exception("non");
			return default(T);
			
		}
		MyNode<T> cur = head.nextNode;
		for(int i = 0; i < index; i++)
		{
			cur = cur.nextNode;
		}
		size--;
		return cur.Value;
	}

	public bool Contains(T element)
	{
		MyNode<T> cur = head.nextNode;
		for(int i = 0; i < size; i++)
		{
			if (cur.Value.Equals(element)) return true;
			cur = cur.nextNode;
		}
		return false;
	}

	public void Clear()
	{
		if (size == 0) return;
		MyNode<T> next = head.nextNode;
		next.preNode = null;
		head.nextNode = null;
		last = head;
		size = 0;
	}
	public void InsertAt(T element, int index)
	{
		if (size - 1 < index) return;
		MyNode<T> newNode = new MyNode<T>(element);
		MyNode<T> cur = FindNodeByIndex(index);
		MyNode<T> post = cur.nextNode;
		MyNode<T> pre = cur.preNode;
		if(post != null)
		{
			post.preNode = newNode;
			newNode.nextNode = post;
		}
		else
		{
			last = newNode;
		}
		pre.nextNode = newNode;
		newNode.preNode = pre;
	}

	private MyNode<T> FindNodeByIndex(int index)
	{
        MyNode<T> cur = head.nextNode;
        for (int i = 0; i < index; i++)
        {
            cur = cur.nextNode;
        }
		return cur;
    }

	public void DeleteAt(int index)
	{
		if (IndexIsGreaterThanLength(index)) return;
		MyNode<T> cur = FindNodeByIndex(index);
		MyNode<T> pre = cur.preNode;
		MyNode<T> post = cur.nextNode;
		cur.nextNode = null;
		cur.preNode = null;
		if (post != null)
		{
			post.preNode = pre;
		}else
		{
			last = pre;
		}
        pre.nextNode = post;
        size--;
	}
	private bool IndexIsGreaterThanLength(int index)
	{
		return index > size - 1;

    }

	public T Find(int index)
	{
		if (IndexIsGreaterThanLength(index))
		{
			//throw new Exception("index is Out of bound");
			return default(T);
		}
		MyNode<T> cur = FindNodeByIndex(index);
		return cur.Value;

	}

	public void print()
	{
		MyNode<T> cur = head.nextNode;
		Console.WriteLine("this is cur list");
		for(int i = 0; i < size; i++)
		{
			Console.Write(cur.Value + ", ");
			cur = cur.nextNode;
		}
        Console.WriteLine();
        Console.WriteLine("Over!");
    }
}

public class MyNode<T>
{
	internal MyNode<T>? preNode;
	internal MyNode<T>? nextNode;
	private T value;
	internal T Value {
		get
		{
			return value;
		}
		set
		{
			value = Value;
		}
	}
	public MyNode()
	{
		value = default(T);
	}
	public MyNode(T value)
	{
		this.value = value;
		preNode = null;
		nextNode = null;
	}
}



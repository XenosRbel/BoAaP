using System.Collections;
using System.Collections.Generic;

namespace Laba8
{
	public class DoubleLinkedList<T>
	{
		public int Count { get; private set; }
		public bool IsEmpty { get { return Count == 0; } }
		public DoubleNode<T> Head { get; set; }
		public DoubleNode<T> Tail { get; set; }

		public void PrintForward() 
		{
			var node = Head;
			if (Head == Head.Next)
			{
				System.Console.WriteLine("The end of linked list");
			}
			else
			{
				do
				{
					System.Console.WriteLine(node.Data.ToString());
					node = node.Next;
				} while (node != Head);
			}
		}

		public void PrintBack() 
		{
			var node = Head;
			if (Head == Head.Next)
			{
				System.Console.WriteLine("The end of linked list");
			}
			else
			{
				do
				{
					node = node.Previous;
					System.Console.WriteLine(node.Data.ToString());
				} while (node != Head);
			}
		}

		public void Add(T data)
		{
			var node = new DoubleNode<T>(data);

			if (Head == null)
				Head = node;
			else
			{
				Tail.Next = node;
				node.Previous = Tail;
			}
			Tail = node;
			Count++;
		}
		public void AddFirst(T data)
		{
			var node = new DoubleNode<T>(data);
			var temp = Head;

			node.Next = temp;
			Head = node;

			if (Count == 0)
				Tail = Head;
			else
				temp.Previous = node;

			Count++;
		}

		public bool Remove(T data)
		{
			var current = Head;

			while (current != null)
			{
				if (current.Data.Equals(data))
				{
					break;
				}
				current = current.Next;
			}
			if (current != null)
			{
				if (current.Next != null)
				{
					current.Next.Previous = current.Previous;
				}
				else
				{
					Tail = current.Previous;
				}

				if (current.Previous != null)
				{
					current.Previous.Next = current.Next;
				}
				else
				{
					Head = current.Next;
				}

				Count--;
				return true;
			}
			return false;
		}

		public void Clear()
		{
			Head = null;
			Tail = null;
			Count = 0;
		}

		public bool Contains(T data)
		{
			var current = Head;

			while (current != null)
			{
				if (current.Data.Equals(data))
					return true;

				current = current.Next;
			}
			return false;
		}

		public void ToRing()
		{
			Tail.Next = Head;
			Head.Previous = Tail; 
		}
	}
}

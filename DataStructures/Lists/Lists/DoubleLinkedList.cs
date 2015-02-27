using System;
using System.Collections.Generic;

namespace Lists
{
	public class DoubleLinkedList<T>:IEnumerable<T>
	{
		private class DoubleLinkedListNode<T>
		{
			public DoubleLinkedListNode<T> Prev{ get; set;}

			public DoubleLinkedListNode<T> Next{ get; set;}

			public T Value{get;set;}

			public DoubleLinkedListNode(T value)
			{
				this.Value = value;
			}
		}

		public int Count{ get; private set; }

		private DoubleLinkedListNode<T> Head{ get; set;}

		private DoubleLinkedListNode<T> Tail{ get; set;}

		public DoubleLinkedList ()
		{
		}

		public void AddFirst(T value)
		{
			var newNode = new DoubleLinkedListNode<T> (value); 
			if (this.Head == null) {
				this.Head = newNode;
				this.Tail = newNode;
			}
			else 
			{
				this.Head.Prev = newNode;
				newNode.Next = this.Head;
				this.Head = newNode;
			}
			++this.Count;
		}

		public void AddLast(T value)
		{
			var newNode = new DoubleLinkedListNode<T> (value); 
			if (this.Tail == null) {
				this.Head = newNode;
				this.Tail = newNode;
			}
			else 
			{
				this.Tail.Next = newNode;
				newNode.Prev = this.Tail;
				this.Tail = newNode;
			}
			++this.Count;
		}

		public IEnumerator<T> GetEnumerator ()
		{
			var current = this.Head;
			while(current!=null)
			{
				yield return current.Value;
				current = current.Next;
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}
	}
}


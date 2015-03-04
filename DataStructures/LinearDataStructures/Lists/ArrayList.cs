using System;
using System.Linq;
using System.Collections.Generic;


namespace Lists
{
	public class ArrayList<T>: IEnumerable<T>
	{
		private const int DefaultCapacity = 4;

		private T[] values;

		private int lastItemIndex;

		public int Capacity{ get; private set; }

		public int Count{ get; private set; }

		public T this [int index] 
		{
			get 
			{
				if (index < 0 || this.Count <= index) 
				{
					throw new IndexOutOfRangeException ("Index is outside the boundaries of the ArrayList");
				}
				return this.values [index];
			}
			set
			{
				if (index < 0 || this.Count <= index) 
				{
					throw new IndexOutOfRangeException ("Index is outside the boundaries of the ArrayList");
				}
				this.values [index] = value;
			}
		}

		public ArrayList () : this (DefaultCapacity)
		{
			;
		}

		public ArrayList (int capacity)
		{
			this.Capacity = capacity;
			this.values = new T[this.Capacity];
			this.lastItemIndex = 0;
		}

		public ArrayList (IEnumerable<T> collection)
			: this (collection.Count ())
		{
			foreach (var item in collection) 
			{
				this.Add (item);
			}
		}

		public void Add (T value)
		{
			if (this.Count == this.Capacity) 
			{
				this.ExpandAndReaddItems ();
			}
			this.values [this.lastItemIndex] = value;
			++this.lastItemIndex;
			++this.Count;
		}

		private void ExpandAndReaddItems ()
		{
			this.Capacity *= 2;
			var newValues = new T[this.Capacity];
			for (int i = 0; i < this.values.Length; i++)
			{
				newValues [i] = this.values [i];
			}
			this.values = newValues;
		}

		public IEnumerator<T> GetEnumerator ()
		{
			for (int i = 0; i < this.Count; i++) 
			{
				yield return this.values [i];
			}
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}
	}
}


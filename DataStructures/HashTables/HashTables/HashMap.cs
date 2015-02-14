using System;
using System.Linq;
using System.Collections.Generic;

namespace HashTables
{
	public class HashMap<K,V>:IEnumerable<KeyValuePair<K,V>>
	{
		private const int InitialCapacity = 16;
		private LinkedList<KeyValuePair<K,V>>[] values;

		public HashMap ()
		{
			this.Capacity = InitialCapacity;
			this.Count = 0;
			this.values = new LinkedList<KeyValuePair<K,V>>[this.Capacity];
		}

		public int Capacity { private set; get; }

		public int Count{ private set; get;}

		public void Add(K key, V value){
			var index = this.Hash (key);
			if (this.values [index] == null) {
				this.values = new List<V> ();
			}
			this.values [index].AddLast (value);
			++this.Count;

			if (this.Count >= 0.75 * this.Capacity) {
				this.ExpandAndRearrangeItems ();
			}
		}

		private int Hash(K key){
			var hashCode = key.GetHashCode ();
			hashCode %= this.Capacity;
			if (hashCode < 0) {
				hashCode *= -1;
			}
			return hashCode;
		}

		private void ExpandAndRearrangeItems(){
			this.Count = 0;
			this.Capacity *= 2;
			var oldValues = (List<KeyValuePair<K,V>>[])this.values.Clone ();
			this.values = new LinkedList<KeyValuePair<K, V>>[this.Capacity];
			foreach (var itemsList in oldValues) {
				foreach (var item in itemsList) {
					this.Add (item.Key, item.Value);
				}
			}
		}

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<K,V>> GetEnumerator ()
		{
			foreach (var itemsList in this.values) {
				foreach (var item in itemsList) {
					yield return item;
				}
			}
		}

		#endregion

		#region IEnumerable implementation

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator ()
		{
			return this.GetEnumerator ();
		}

		#endregion
	}	
}


using System;
using System.Linq;
using System.Collections.Generic;

namespace HashTables
{
	public class HashMap<K,V>:IEnumerable<KeyValuePair<K,V>>
	{
		private const int InitialCapacity = 16;
		private List<KeyValuePair<K,V>>[] values;

		public HashMap ()
		{
			this.Capacity = InitialCapacity;
			this.Count = 0;
			this.values = new List<KeyValuePair<K,V>>[this.Capacity];
		}

		public int Capacity { private set; get; }

		public int Count{ private set; get; }

		public V this [K key] {
			get {
				return this.Get (key);
			}
			set {
				if (this.Contains (key)) {
					var index = this.Hash (key);
					for (int i = 0; i < this.values [index].Count; i++) {
						if (this.values [index] [i].Key.Equals (key)) {
							this.values [index] [i] = new KeyValuePair<K, V> (key, value);
							return;
						}
					}
				} else {
					this.Add (key, value);
				}
			}
		}

		public void Add (K key, V value)
		{
			if (this.Contains (key)) {
				throw new ArgumentException ("The key already exists in the HashMap");
			}
			var index = this.Hash (key);
			if (this.values [index] == null) {
				this.values [index] = new List<KeyValuePair<K,V>> ();
			}
			this.values [index].Add (new KeyValuePair<K,V> (key, value));
			++this.Count;

			if (this.Count >= 0.75 * this.Capacity) {
				this.ExpandAndRearrangeItems ();
			}
		}

		public V Get (K key)
		{
			if (!this.Contains (key)) {
				throw new ArgumentException ("The key does not exists in the HashMap");
			}
			int index = this.Hash (key);
			var possibleValues = this.values [index];
			foreach (var item in possibleValues) {
				if (item.Key.Equals (key)) {
					return item.Value;
				}
			}
			return default(V);
		}

		public bool Contains (K key)
		{
			int index = this.Hash (key);
			if (this.values [index] == null) {
				return false;
			}
			foreach (var item in this.values[index]) {
				if (item.Key.Equals (key)) {
					return true;
				}
			}
			return false;
		}

		private int Hash (K key)
		{
			var hashCode = key.GetHashCode ();
			hashCode %= this.Capacity;
			if (hashCode < 0) {
				hashCode *= -1;
			}
			return hashCode;
		}

		private void ExpandAndRearrangeItems ()
		{
			this.Count = 0;
			this.Capacity *= 2;
			var oldValues = (List<KeyValuePair<K,V>>[])this.values.Clone ();
			this.values = new List<KeyValuePair<K, V>>[this.Capacity];
			foreach (var itemsList in oldValues) {
				if (itemsList != null) {
					foreach (var item in itemsList) {
						this.Add (item.Key, item.Value);
					}
				}
			}
		}

		#region IEnumerable implementation

		public IEnumerator<KeyValuePair<K,V>> GetEnumerator ()
		{
			foreach (var itemsList in this.values) {
				if (itemsList != null) {
					foreach (var item in itemsList) {
						yield return item;
					}
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


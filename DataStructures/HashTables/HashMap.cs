namespace HashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using Extensions;

    public class HashMap<TK, TV> : IHashMap<TK, TV>, IEnumerable<KeyValuePair<TK, TV>>
    {
        private const int InitialCapacity = 16;

        private List<KeyValuePair<TK, TV>>[] values;

        public HashMap()
        {
            this.Capacity = InitialCapacity;
            this.Count = 0;
            this.values = new List<KeyValuePair<TK, TV>>[this.Capacity];
        }

        public HashMap(IEnumerable<KeyValuePair<TK, TV>> values)
            : this()
        {
            values.ForEach(this.Add);
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public TV this[TK key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                if (this.ContainsKey(key))
                {
                    this.Set(key, value);
                }
                else
                {
                    this.Add(key, value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            foreach (var pairItemsList in this.values)
            {
                if (pairItemsList == null)
                {
                    continue;
                }

                foreach (var pair in pairItemsList)
                {
                    yield return pair;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void Set(TK key, TV value)
        {
            if (!this.ContainsKey(key))
            {
                throw new InvalidOperationException("Missing items cannot be set");
            }

            var index = this.GetIndexOf(key);
            var pairItemsList = this.values[index];

            for (var i = 0; i < pairItemsList.Count; i++)
            {
                if (pairItemsList[i].Key.Equals(key))
                {
                    pairItemsList[i] = new KeyValuePair<TK, TV>(key, value);
                    return;
                }
            }
        }

        public void Add(KeyValuePair<TK, TV> pair)
        {
            this.Add(pair.Key, pair.Value);
        }

        public void Add(TK key, TV value)
        {
            if (this.ContainsKey(key))
            {
                throw new ArgumentException("The key already exists in the HashMap");
            }

            var index = this.GetIndexOf(key);
            if (this.values[index] == null)
            {
                this.values[index] = new List<KeyValuePair<TK, TV>>();
            }

            this.values[index].Add(new KeyValuePair<TK, TV>(key, value));
            ++this.Count;

            if (this.Count >= 0.75 * this.Capacity)
            {
                this.ExpandAndRearrangeItems();
            }
        }

        public TV Get(TK key)
        {
            if (!this.ContainsKey(key))
            {
                throw new ArgumentException("The key does not exists in the HashMap");
            }

            var index = this.GetIndexOf(key);
            var pairItemsList = this.values[index];
            foreach (var item in pairItemsList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(TV);
        }

        public bool ContainsKey(TK key)
        {
            var index = this.GetIndexOf(key);
            if (this.values[index] == null)
            {
                return false;
            }

            foreach (var item in this.values[index])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private int GetIndexOf(TK key)
        {
            var hashCode = key.GetHashCode();
            hashCode %= this.Capacity;

            if (hashCode < 0)
            {
                hashCode *= -1;
            }

            return hashCode;
        }

        private void ExpandAndRearrangeItems()
        {
            this.Count = 0;
            this.Capacity *= 2;

            var oldValues = (List<KeyValuePair<TK, TV>>[])this.values.Clone();
            this.values = new List<KeyValuePair<TK, TV>>[this.Capacity];

            foreach (var itemsList in oldValues)
            {
                if (itemsList == null)
                {
                    continue;
                }

                foreach (var item in itemsList)
                {
                    this.Add(item.Key, item.Value);
                }
            }
        }
    }
}
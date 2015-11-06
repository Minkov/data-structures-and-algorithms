namespace HashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    public class HashMap<TK, TV> : IEnumerable<KeyValuePair<TK, TV>>
    {
        private const int InitialCapacity = 16;
        private List<KeyValuePair<TK, TV>>[] values;

        public HashMap()
        {
            Capacity = InitialCapacity;
            Count = 0;
            values = new List<KeyValuePair<TK, TV>>[Capacity];
        }

        public HashMap(IEnumerable<KeyValuePair<TK, TV>> values)
            : this()
        {
            values.ForEach(Add);
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public TV this[TK key]
        {
            get { return Get(key); }

            set
            {
                if (Contains(key))
                {
                    Set(key, value);
                }
                else
                {
                    Add(key, value);
                }
            }
        }

        public IEnumerator<KeyValuePair<TK, TV>> GetEnumerator()
        {
            return (values.Where(itemsList => itemsList != null)
                .SelectMany(itemsList => itemsList)).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Set(TK key, TV value)
        {
            var index = Hash(key);
            for (var i = 0; i < values[index].Count; i++)
            {
                if (values[index][i].Key.Equals(key))
                {
                    values[index][i] =
                        new KeyValuePair<TK, TV>(key, value);
                    return;
                }
            }
        }

        public void Add(KeyValuePair<TK, TV> pair)
        {
            Add(pair.Key, pair.Value);
        }

        public void Add(TK key, TV value)
        {
            if (Contains(key))
            {
                throw new ArgumentException("The key already exists in the HashMap");
            }

            var index = Hash(key);
            if (values[index] == null)
            {
                values[index] = new List<KeyValuePair<TK, TV>>();
            }

            values[index].Add(new KeyValuePair<TK, TV>(key, value));
            ++Count;

            if (Count >= 0.75*Capacity)
            {
                ExpandAndRearrangeItems();
            }
        }

        public TV Get(TK key)
        {
            if (!Contains(key))
            {
                throw new ArgumentException("The key does not exists in the HashMap");
            }

            var index = Hash(key);
            var possibleValues = values[index];
            foreach (var item in possibleValues)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }

            return default(TV);
        }

        public bool Contains(TK key)
        {
            var index = Hash(key);
            if (values[index] == null)
            {
                return false;
            }

            foreach (var item in values[index])
            {
                if (item.Key.Equals(key))
                {
                    return true;
                }
            }

            return false;
        }

        private int Hash(TK key)
        {
            var hashCode = key.GetHashCode();
            hashCode %= Capacity;
            if (hashCode < 0)
            {
                hashCode *= -1;
            }

            return hashCode;
        }

        private void ExpandAndRearrangeItems()
        {
            Count = 0;
            Capacity *= 2;
            var oldValues = (List<KeyValuePair<TK, TV>>[]) values.Clone();
            values = new List<KeyValuePair<TK, TV>>[Capacity];

            foreach (var itemsList in oldValues)
            {
                if (itemsList == null)
                {
                    continue;
                }

                foreach (var item in itemsList)
                {
                    Add(item.Key, item.Value);
                }
            }
        }
    }
}
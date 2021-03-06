﻿namespace HashTables
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class HashSet<T> : IHashSet<T>, IEnumerable<T>, ICloneable
    {
        private const int InitialCapacity = 16;
        private const float ResizeCoeff = 0.75f;

        private List<T>[] values;

        public HashSet()
        {
            this.Count = 0;
            this.Capacity = InitialCapacity;
            this.values = new List<T>[this.Capacity];
        }

        public int Capacity { get; private set; }

        public int Count { get; private set; }

        public void Add(T value)
        {
            var index = this.GetIndexOf(value);
            if (this.values[index] == null)
            {
                this.values[index] = new List<T>();
            }

            this.values[index].Add(value);
            ++this.Count;

            if (this.Count >= this.Capacity * ResizeCoeff)
            {
                this.ResizeAndReadd();
            }
        }

        public bool Contains(T value)
        {
            var index = this.GetIndexOf(value);
            return this.values[index] != null &&
                    this.values[index].Contains(value);
        }

        public void Remove(T value)
        {
            var index = this.GetIndexOf(value);

            if (this.values[index] == null ||
                !this.values[index].Remove(value))
            {
                throw new ArgumentNullException(paramName: "Item", message: "Element not found");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var valuesList in this.values)
            {
                if (valuesList == null)
                {
                    continue;
                }

                foreach (var value in valuesList)
                {
                    yield return value;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public object Clone()
        {
            var clone = new HashSet<T>();
            foreach (var value in this)
            {
                clone.Add(value);
            }

            return clone;
        }

        private void ResizeAndReadd()
        {
            this.Capacity *= 2;
            var oldHash = (HashSet<T>)this.Clone();
            this.values = new List<T>[this.Capacity];
        }

        private int GetIndexOf(T value)
        {
            var hashCode = value.GetHashCode();
            if (hashCode < 0)
            {
                hashCode *= -1;
            }

            var index = hashCode % this.Capacity;
            return index;
        }
    }
}

namespace HashTables
{
    using System.Collections.Generic;
     
    public interface IHashMap<TK, TV>
    {
        int Count { get; }

        TV this[TK key] { get; set; }

        void Add(KeyValuePair<TK, TV> pair);

        void Add(TK key, TV value);

        TV Get(TK key);

        void Set(TK key, TV value);

        bool ContainsKey(TK key);
    }
}
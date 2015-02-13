using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combinatorics
{
    public static class CombinatoricExtensions
    {
        static void Swap<T>(T[] items, int i, int j)
        {
            T temp = items[i];
            items[i] = items[j];
            items[j] = temp;
        }

        class PermutationsEquliatyComparer<T> : IEqualityComparer<T[]>
        {
            public bool Equals(T[] x, T[] y)
            {
                if (x.Length != y.Length)
                {
                    return false;
                }
                for (int i = 0; i < x.Length; i++)
                {
                    if (!x[i].Equals(y[i]))
                    {
                        return false;
                    }
                }
                return true;
            }

            public int GetHashCode(T[] obj)
            {
                return obj.Sum(o => o.GetHashCode());
            }
        }

        #region Variations

        public static IEnumerable<T[]> GetVariations<T>(this IEnumerable<T> collection, int count)
        {
            IList<T[]> variations = new List<T[]>();

            T[] variation = new T[count];
            T[] items = collection.ToArray();
            bool[] used = new bool[items.Length];

            GenerateVariations(items, 0, variation, variations, used);

            return variations;
        }

        private static void GenerateVariations<T>(T[] items, int index, T[] variation, IList<T[]> variations, bool[] used)
        {
            if (index == variation.Length)
            {
                variations.Add((T[])variation.Clone());
                return;
            }
            
            for (int i = 0; i < items.Length; i++)
            {
                if (!used[i])
                {
                    variation[index] = items[i];
                    used[i] = true;
                    GenerateVariations(items, index + 1, variation, variations, used);
                    used[i] = false;
                }
            }
        }

        #endregion

        #region Permutations

        public static IEnumerable<T[]> GetPermutations<T>(this IEnumerable<T> items)
        {
            ISet<T[]> permutations = new HashSet<T[]>(new PermutationsEquliatyComparer<T>());

            Permute(items.ToArray(), 0, permutations);
            return permutations.ToArray();
        }

        private static void Permute<T>(T[] items, int position, ISet<T[]> permutations)
        {
            if (position == items.Length)
            {
                permutations.Add((T[])items.Clone());
                return;
            }
            for (int i = position; i < items.Length; i++)
            {
                Swap(items, position, i);
                Permute((T[])items.Clone(), position + 1, permutations);
                Swap(items, position, i);
            }
        }

        #endregion

        #region Combinations

        public static IEnumerable<T[]> GetCombinations<T>(this IEnumerable<T> items, int count)
        {
            List<T[]> combinations = new List<T[]>();
            var combination = new T[count];
            GetCombinations(items.ToArray(), 0, 0, combination, combinations);
            return combinations.ToArray();
        }

        private static void GetCombinations<T>(T[] items, int index, int next, T[] combination, List<T[]> combinations)
        {
            if (index == combination.Length)
            {
                combinations.Add((T[])combination.Clone());
                return;
            }
            for (int i = next; i < items.Length; i++)
            {
                combination[index] = items[i];
                GetCombinations(items, index + 1, i + 1, combination, combinations);
            }
        }
        #endregion
    }

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Variations:");
            (new int[] { 1, 2, 3 }).GetVariations(3)
                                      .ForEach(variation => Console.WriteLine(string.Join(", ", variation)));
            Console.WriteLine(new string('*', 50));

            //Console.WriteLine("Permutations:");
            //(new int[] { 1, 2, 3 }).GetPermutations()
            //                          .ForEach(variation => Console.WriteLine(string.Join(", ", variation)));
            //Console.WriteLine(new string('*', 50));

            //Console.WriteLine("Combinations:");
            //(new int[] { 1, 2, 3 }).GetCombinations(2)
            //                          .ForEach(variation => Console.WriteLine(string.Join(", ", variation)));
        }
    }
}
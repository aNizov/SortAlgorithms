using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
    public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма быстрой сортировки. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> QuickSort<T>(IList<T> array) where T : IComparable
        {
            return QuickSort(array, 0, array.Count - 1);
        }
        private static IList<T> QuickSort<T>(IList<T> array, int p, int r) where T : IComparable
        {

            if (p < r)
            {
                int q = Partition(array, p, r);
                QuickSort(array, p, q - 1);
                QuickSort(array, q + 1, r);
            }
            return array;
        }
        private static int Partition<T>(IList<T> array, int p, int r) where T : IComparable
        {
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (array[j].CompareTo(array[r]) <= 0)
                {
                    i++;
                    array.SwapElements(i, j);
                }
            }
            array.SwapElements(i + 1, r);
            return i + 1;
        }

        /// <summary>
        /// Имплементация алгоритма быстрой сортировки. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> QuickSortByDescending<T>(IList<T> array) where T : IComparable
        {
            return QuickSortByDescending(array, 0, array.Count - 1);
        }
        private static IList<T> QuickSortByDescending<T>(IList<T> array, int p, int r) where T : IComparable
        {

            if (p < r)
            {
                int q = PartitionByDescending(array, p, r);
                QuickSortByDescending(array, p, q - 1);
                QuickSortByDescending(array, q + 1, r);
            }
            return array;
        }
        private static int PartitionByDescending<T>(IList<T> array, int p, int r) where T : IComparable
        {
            int i = p - 1;
            for (int j = p; j < r; j++)
            {
                if (array[j].CompareTo(array[r]) >= 0)
                {
                    i++;
                    array.SwapElements(i, j);
                }
            }
            array.SwapElements(i + 1, r);
            return i + 1;
        }
    }
}

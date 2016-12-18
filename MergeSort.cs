using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
    public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма итеративной сортировки слиянием. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> MergeSort<T>(IList<T> array) where T : IComparable
        {
            int n = array.Count;
            for (int i = 1; i < n; i *= 2)
            {
                for (int j = 0; j < n - i; j += 2 * i)
                {
                    Merge(array, j, j + i, (j + 2 * i < n ? j + 2 * i : n));
                }
            }
            return array;
        }
        /// <summary>
        /// Имплементация алгоритма итеративной сортировки слиянием. Сортировка по убыванию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> MergeSortByDescending<T>(IList<T> array) where T : IComparable
        {
            int n = array.Count;
            for (int i = 1; i < n; i *= 2)
            {
                for (int j = 0; j < n - i; j += 2 * i)
                {
                    MergeByDescending(array, j, j + i, (j + 2 * i < n ? j + 2 * i : n));
                }
            }
            return array;
        }
        private static IList<T> Merge<T>(IList<T> array, int left, int mid, int right) where T : IComparable
        {
            int it1 = 0;
            int it2 = 0;
            T[] result = new T[right - left];
            while (left + it1 < mid && mid + it2 < right)
                if (array[left + it1].CompareTo(array[mid + it2]) < 0)
                {
                    result[it1 + it2] = array[left + it1];
                    it1 += 1;
                }
                else
                {
                    result[it1 + it2] = array[mid + it2];
                    it2 += 1;
                }
            while (left + it1 < mid)
            {
                result[it1 + it2] = array[left + it1];
                it1 += 1;
            }
            while (mid + it2 < right)
            {
                result[it1 + it2] = array[mid + it2];
                it2 += 1;
            }
            for (int i = 0; i < it1 + it2; i++)
            {
                array[left + i] = result[i];
            }
            return array;
        }

        private static IList<T> MergeByDescending<T>(IList<T> array, int left, int mid, int right) where T : IComparable
        {
            int it1 = 0;
            int it2 = 0;
            T[] result = new T[right - left];
            while (left + it1 < mid && mid + it2 < right)
                if (array[left + it1].CompareTo(array[mid + it2]) > 0)
                {
                    result[it1 + it2] = array[left + it1];
                    it1 += 1;
                }
                else
                {
                    result[it1 + it2] = array[mid + it2];
                    it2 += 1;
                }
            while (left + it1 < mid)
            {
                result[it1 + it2] = array[left + it1];
                it1 += 1;
            }
            while (mid + it2 < right)
            {
                result[it1 + it2] = array[mid + it2];
                it2 += 1;
            }
            for (int i = 0; i < it1 + it2; i++)
            {
                array[left + i] = result[i];
            }
            return array;
        }
    }
}

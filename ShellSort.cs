using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
    public static partial class SortAlgorithms
    {
        /// <summary>
        /// Имплементация алгоритма сортировки Шелла. Сортировка по возрастанию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> ShellSort<T>(IList<T> array) where T : IComparable
        {
            int j;
            int step = array.Count / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Count - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j].CompareTo(array[j + step]) > 0))
                    {
                        array.SwapElements(j, j + step);
                        j -= step;
                    }
                }
                step = step / 2;
            }
            return array;
        }
        /// <summary>
        /// Имплементация алгоритма сортировки Шелла. Сортировка по убыванию.
        /// </summary>
        /// <returns>Отсортированный IList</returns>
        /// <param name="array">IList к сортировке</param>
        public static IList<T> ShellSortByDescending<T>(IList<T> array) where T : IComparable
        {
            int j;
            int step = array.Count / 2;
            while (step > 0)
            {
                for (int i = 0; i < (array.Count - step); i++)
                {
                    j = i;
                    while ((j >= 0) && (array[j].CompareTo(array[j + step]) <= 0))
                    {
                        array.SwapElements(j, j + step);
                        j -= step;
                    }
                }
                step = step / 2;
            }
            return array;
        }

    }
}

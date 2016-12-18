using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
	public static partial class SortAlgorithms
    {
		/// <summary>
		/// Имплементация алгоритма сортировки выбором. Сортировка по возрастанию.
		/// </summary>
		/// <returns>Отсортированный IList</returns>
		/// <param name="array">IList к сортировке</param>
		public static IList<T> SelectionSort<T>(IList<T> array) where T : IComparable
		{
			for (int i = 0; i < array.Count - 1; ++i)
			{
				var min = i;

				for (int j = i + 1; j < array.Count; ++j)
				{
					if (array[j].CompareTo(array[min]) < 0)
					{
						min = j;
					}
				}
				array.SwapElements(min, i);
			}
			return array;
		}
		/// <summary>
		/// Имплементация алгоритма сортировки выбором. Сортировка по убыванию.
		/// </summary>
		/// <returns>Отсортированный IList</returns>
		/// <param name="array">IList к сортировке</param>
		public static IList<T> SelectionSortByDescending<T>(IList<T> array) where T : IComparable
		{
			for (int i = 0; i < array.Count - 1; ++i)
			{
				var min = i;

				for (int j = i + 1; j < array.Count; ++j)
				{
					if (array[j].CompareTo(array[min]) > 0)
					{
						min = j;
					}
				}
				array.SwapElements(min, i);
			}
			return array;
		}
	}
}

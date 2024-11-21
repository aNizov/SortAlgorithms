using System;
using System.Collections.Generic;
namespace ANSortAlgorithms
{
	public static partial class SortAlgorithms
    {

		/// <summary>
		/// Имплементация алгоритма пузырьковой сортировки. Сортировка по возрастанию.
		/// </summary>
		/// <returns>Отсортированный IEnumerable</returns>
		/// <param name="array">IEnumerable к сортировке</param>
		public static IList<T> BubbleSort<T>(IList<T> array) where T : IComparable
		{
			if (array != null)
			{
				for (int i = 0; i < array.Count; i++)
				{
					for (int j = array.Count - 1; j > i; j--)
					{
						if (array[j].CompareTo(array[j - 1]) < 0)
						{
							array.SwapElements(j, j - 1);
						}
					}
				}
			}
			return array;
		}
		/// <summary>
		/// Имплементация алгоритма пузырьковой сортировки. Сортировка по убыванию
		/// </summary>
		/// <returns>Отсортированный IEnumerable</returns>
		/// <param name="array">IEnumerable к сортировке</param>
		public static IList<T> BubbleSortByDescending<T>(IList<T> array) where T : IComparable<T>
		{
			if (array != null)
			{
				for (int i = 0; i < array.Count; i++)
				{
					for (int j = array.Count - 1; j > i; j--)
					{
						if (array[j].CompareTo(array[j - 1]) > 0)
						{
							array.SwapElements(j, j - 1);
						}
					}
				}
			}
			return array;
		}
	}
}

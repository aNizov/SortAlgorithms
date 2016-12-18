using System;
using System.Collections.Generic;
namespace ANSortingAlgorithms
{
	public static partial class SortingAlgorithms
	{
		/// <summary>
		/// Алгоритм пузырьковой сортировки
		/// </summary>
		/// <returns>Отсортированный IEnumerable</returns>
		/// <param name="array">IEnumerable к сортировке</param>
		public static IList<T> BubbleSort<T>(this IList<T> array) where T : IComparable<T>
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
	}
}

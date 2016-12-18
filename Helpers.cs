using System;
using System.Collections.Generic;

namespace ANSortAlgorithms
{
	public static partial class SortAlgorithms
    {
		/// <summary>
		/// Метод расширения
		/// переставляет 2 елемента с выбранными индексами
		/// </summary>
		/// <param name="array"></param>
		/// <param name="firstIndex">Первый элемент для перестановки</param>
		/// <param name="secondIndex">Второй элемент для перестановки</param>
		public static void SwapElements<T>(this IList<T> array, int firstIndex, int secondIndex)
		{
			if (firstIndex != secondIndex)
			{
				T secondValue = array[secondIndex];
				array[secondIndex] = array[firstIndex];
				array[firstIndex] = secondValue;
			}
		}

		public static T FindMax<T>(this IList<T> array) where T : IComparable
		{
			T max = array[0];
			for (int i = 0; i < array.Count; i++)
			{
				if (max.CompareTo(array[i]) < 0)
				{
					max = array[i];
				}
			}
			return max;
		}
	}
}

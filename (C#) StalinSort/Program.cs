using System;
using System.Collections.Generic;
using System.Linq;

namespace StalinSort
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Enter test array length");
			int testArrayLength = 0;

			do
			{
				int.TryParse(Console.ReadLine(), out testArrayLength);
				if (testArrayLength < 3)
					Console.WriteLine("Array length should be 3 or greater");
			} while (testArrayLength < 3);

			int[] array = new int[testArrayLength];
			Random random = new Random();
			for (int k = 0; k < array.Length; k++)
				array[k] = (int)Math.Pow(-1, random.Next(0, 2)) * random.Next(0, 1000);
			
			int[] newArray = StalinSort(array);

			Console.WriteLine("Initial array:");
			DisplayArray(array);

			Console.WriteLine();

			Console.WriteLine("Sorted array:");
			DisplayArray(newArray);

			Console.WriteLine();

			Console.WriteLine("Elements vaporized: " + (array.Length - newArray.Length));
			
			Console.WriteLine();

			Console.WriteLine("Program end");
			Console.ReadKey();
		}

		static void DisplayArray(int[] array)
		{
			for (int k = 0; k < array.Length; k++)
				Console.WriteLine($"[{k}]: {array[k]}");
		}

		static int[] StalinSort(int[] array)
		{
			List<int> list = array.ToList();
			
			for (int k = 1; k < list.Count; k++)
				if (list[k - 1] > list[k])
					list.RemoveAt(k--);

			return list.ToArray();
		}
	}
}
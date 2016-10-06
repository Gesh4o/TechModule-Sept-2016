namespace DictionariesLambdaAndLINQ
{
    using System;
	using System.Linq;
	
    class FoldAndSumMain
    {
        static void Main(string[] args)
        {
			int[] arr = Console.ReadLine()
							.Split(' ')
							.Select(int.Parse) // Selecting a value will transform the value in different form: here it changes the value from string to int.
					  //	.Select(s => int.Parse(s))  *This means for every element in given collection I name it: "s" and I want to the following operation: "int.Parse(s)".
							.ToArray();
							
			int k = arr.Length / 4;
			
			// Take our first k elements in reversed order.
			int[] leftRow = arr.Take(k).Reverse().ToArray();
			
			// Take our array, reverse it and take the first k elements which in result will give us the last k values from the original array in reversed order.
			int[] rightRow = arr.Reverse().Take(k).ToArray();
			
			// Join the previously taken arrays into a new one.
			int[] combinedArray = leftRow.Concat(rightRow).ToArray();
			
			// Take the elements in the "middle".
			// *Note that every time we use the LINQ methods like: "Take", "Concat", "OrderBy" a NEW collection is returned! (Not an array but a collection)
			int[] middleElements = arr.Skip(k).Take(2 * k).ToArray();
			
			
			
			
			// For every element in our collection grab it alongside with it's index in the array. Add the current value with the value on the same position
			// from the other array.
			// Basically this will transform the following
			// From: [1,2,3,4] +
		    //		 [4,2,0,1] =			
			// To:   [5,4,3,5]
			int[] sumArr =
			  combinedArray.Select((x, index) => x + middleElements[index]).ToArray();
			
			
			Console.WriteLine(string.Join(" ", sumArr));
        }
    }
}

namespace DictionariesLambdaAndLINQ
{
    using System;
    using System.Collections.Generic;

    class CountRealNumbersMain
    {
        static void Main(string[] args)
        {
			// Read input.
            string[] numbers = Console.ReadLine().Split(' ');
			
			// We will store every number as a KEY and it's repetition count as VALUE. 
			// e.g. [1 -> 0], [2.4 -> 2] and so on.
            SortedDictionary<double, int> numbersByRepetition = new SortedDictionary<double, int>();

            foreach (var num in numbers)
            {
                double parsedNum = double.Parse(num);

				// Check if the number(KEY) is existing in dictionary.
                if (numbersByRepetition.ContainsKey(parsedNum))
                {
					// If yes, we should increment it's repetition count.
                    numbersByRepetition[parsedNum]++;
                }
                else
                {
					// If no, initialize count with value equal to 1.
                    numbersByRepetition[parsedNum] = 1;
                }
            }

			// For each number print it with it's repetition count.
			// *Note we will print the numbers sorted by their KEY values because we use SortedDictionary.
            foreach (double num in numbersByRepetition.Keys)
            {
                Console.WriteLine($"{num} -> {numbersByRepetition[num]}");
            }
        }
    }
}

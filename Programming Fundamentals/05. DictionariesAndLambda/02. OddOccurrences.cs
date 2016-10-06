namespace DictionariesLambdaAndLINQ
{
    using System;
    using System.Collections.Generic;

    class CountOddOccurrencesMain
    {
        static void Main(string[] args)
        {
		// Read input and make sure that we will ignore wordcasing using ToLower() function.
		string input = Console.ReadLine().ToLower();
		string[] words = input.Split(' ');

		Dictionary<string, int> wordsByRepetition = new Dictionary<string, int>();

		// For every words do the exactly same thing that we did in the previous task (see 01. CountRealNumbers)
		foreach (string word in words)
		{
			if (wordsByRepetition.ContainsKey(word)) 
			{
				wordsByRepetition[word]++;
			}
		   else 
		   {
			   wordsByRepetition[word] = 1;
		   }
		}

		// We have our words with their repetition value in our dictionary.
		// We can use a list in order to save all words that have odd amount of repetitions.
		// Why we use list? 
		// - Because it can dinamycally grow in size and we do not know how many words will be repeated odd amount of times.
		List<string> results = new List<string>();

		// We check every pair in our dictionary if the VALUE (from KeyValuePair) is an odd number.
		// If the above is true - our word has shown up in our input odd amount of times.
		foreach (KeyValuePair<string, int> pair in wordsByRepetition)
		{
			if(pair.Value % 2 == 1) 
			{
				results.Add(pair.Key);
			}
		}

		Console.WriteLine(string.Join(", ", results));
        }
    }
}

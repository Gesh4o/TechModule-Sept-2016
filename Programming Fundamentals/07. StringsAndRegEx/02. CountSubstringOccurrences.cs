namespace StringsAndRegex
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class CountOccurrencesMain
    {
        static void Main(string[] args)
        {
			// Read input.
            string text = Console.ReadLine().ToLower();
            string word = Console.ReadLine().ToLower();

			// Initialize counter and check if word is existing in the text.
            int count = 0;
            int index = text.IndexOf(word);
			
			// While there are any matches in the text (the index of the word in the text is not -1)
            while (index != -1)
            {
				// Find next, but start searching for indexes after the last one(index + 1).
                index = text.IndexOf(word, index + 1);
                count++;
            }

			// Display count.
            Console.WriteLine(count);
		}
    }
}
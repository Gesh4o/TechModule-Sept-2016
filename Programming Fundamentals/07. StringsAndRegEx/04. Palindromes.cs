namespace StringsAndRegex
{
    using System;
    using System.Text.RegularExpressions;

    public class PalindromesMain
    {
		// The sorted class here is useful because of two things:
		// 1. It is a set - that means no duplicate values will be inserted.
		// 2. It is sorted - this means that we have the right ordering.
		// See: https://www.dotnetperls.com/sortedset
        public static void Main(string[] args)
        {
			// Match any word with more then one letter.
            Regex regex = new Regex("[a-zA-Z]+");
            MatchCollection matchCollection = regex.Matches(Console.ReadLine());

			// Order them in set.
            SortedSet<string> set = new SortedSet<string>();
			
			// Filter every match which is a palindrome.
            foreach (Match match in matchCollection.Cast<Match>().Where(match => IsPalindrome(match.ToString())))
            {
                set.Add(match.ToString());
            }

			// Display the set.
            Console.WriteLine(string.Join(", ", set));
        }

        private static bool IsPalindrome(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (word[i] != word[word.Length - i - 1])
                {
					// The word is not a palindrome. Return false directly.
                    return false;
                }
            }

			// If this line of code is executed this means that the word is proven to be a palindrome.
            return true;
        }
    }
}

namespace DictionariesLambdaAndLINQ
{
    using System;
	using System.Linq;
	
    class ShortWordsSortedMain
    {
        static void Main(string[] args)
        {
		char[] separators = new char[] {'.',',',':',';','(',')','[',']','\\','\"','\'','/','!','?',' '};

		// Make sure when we are reading the input we ignore word casing
		string sentence = Console.ReadLine().ToLower();

		string[] words = sentence.Split(separators);
		var result = words
		  .Where(w => w != "")
		  .Where(w => w.Length < 5)
	      //  .Where(w => w != "" && w.Length < 5)  *Note that we can have multiple bool expression in our lambda -> like any other if-clause.
	      //  .Where(w => w.Length > 0 && w.Length < 5 ) *The string = "" has length of 0. Don't believe me? Try this one: Console.WriteLine("".Length); and see for yourself
		  .OrderBy(w => w) // Sort the collection using their natural order
		  .Distinct() // Remove duplicated values
		  .ToArray();

		Console.WriteLine(string.Join(", ", result));
        }
    }
}

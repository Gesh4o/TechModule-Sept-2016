namespace ObjectAndClasses
{
    using System;

    public class RandomizeNumbersMain
    {
        public static void Main(string[] args)
        {
            // Read input.
            string[] words = Console.ReadLine().Split();

            // Create object that will generate random values.
            // See: https://msdn.microsoft.com/en-us/library/system.random(v=vs.110).aspx
            Random rnd = new Random();

            // For every element in our words array, generate a random index.
            // Swap the values between current index and the random one.
            for (int i = 0; i < words.Length; i++)
            {
                int randomIndex = rnd.Next(0, words.Length);

                // Save current index value into a temporary variable.
                string oldValue = words[i];

                // Assign new value on the current index.
                words[i] = words[randomIndex];

                // Use that temporary value to complete the swap - assign the old value to the element with current random index
                words[randomIndex] = oldValue;
            }

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }
    }
}

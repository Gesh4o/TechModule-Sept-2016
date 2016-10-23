namespace _02.Ladybugs
{
    using System;
    using System.Linq;

    class LadybugsMain
    {
        static void Main()
        {
            int arraySize = int.Parse(Console.ReadLine());

            bool[] bugPool = new bool[arraySize];

            int[] occupiedIndexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            foreach (int index in occupiedIndexes.Where(n => n >= 0 && n < arraySize))
            {
                bugPool[index] = true;
            }

            string input = Console.ReadLine();

            while (input != "end")
            {
                string[] args = input.Split();
                int bugIndex = int.Parse(args[0]);
                int step = int.Parse(args[2]);
                int initialIndex = bugIndex;

                if (args[1] == "left")
                {
                    step *= -1;
                }

                // Is initialIndex inside the array and the step is different than 0.
                if (initialIndex >= 0 && initialIndex < bugPool.Length && bugPool[initialIndex] && step != 0)
                {
                    while (bugIndex >= 0 && bugIndex < bugPool.Length)
                    {
                        if (!bugPool[bugIndex])
                        {
                            bugPool[bugIndex] = true;
                            break;
                        }

                        bugIndex += step;
                    }

                    bugPool[initialIndex] = false;
                }

                input = Console.ReadLine();
            }


            Console.WriteLine(string.Join(" ", bugPool.Select(isOccupied =>
            {
                if (isOccupied)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            })));
        }
    }
}

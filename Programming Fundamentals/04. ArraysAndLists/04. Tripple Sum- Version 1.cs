namespace Demo
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string[] arrayNumbers = Console.ReadLine().Split();

            int[] array = new int[arrayNumbers.Length];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = int.Parse(arrayNumbers[i]);
            }

            bool isFound = false;
            for (int i = 0; i < array.Length; i++)
            {
                int firstNum = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    int secondNum = array[j];
                    long sum = firstNum + secondNum;

                    for (int k = 0; k < array.Length; k++)
                    {
                        if (array[k] == sum)
                        {
                            Console.WriteLine($"{firstNum} + {secondNum} == {sum}");
                            isFound = true;
                            break;
                        }
                    }
                }
            }

            if (!isFound)
            {
                Console.WriteLine("No");
            }
        }
    }
}

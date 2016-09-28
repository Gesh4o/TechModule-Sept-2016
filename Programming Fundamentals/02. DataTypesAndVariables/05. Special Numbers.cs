namespace DataTypesAndVariables
{
    using System;

    class SpecialNumbersMain
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                // Using arithmetic operations.
                int sum = 0;
                int num = i;
                while (num > 0)
                {
                    sum += num % 10;
                    num /= 10;
                }

                // Using text processing.
                // string num = i.ToString();
                // for (int j = 0; j < num.Length; j++)
                // {
                //     sum += int.Parse(num[j].ToString());
                // }

                bool isSpecial = sum == 5 || sum == 7 || sum == 11;
                Console.WriteLine($"{i} -> {isSpecial}");
            }
        }
    }
}

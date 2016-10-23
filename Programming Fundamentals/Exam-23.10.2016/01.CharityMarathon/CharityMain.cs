namespace _01.CharityMarathon
{
    using System;

    class CharityMain
    {
        static void Main(string[] args)
        {
            int days = int.Parse(Console.ReadLine());
            int runnersToParticipate = int.Parse(Console.ReadLine());
            int avarageLapsPerRunner = int.Parse(Console.ReadLine());
            int lengthOfTrack = int.Parse(Console.ReadLine());
            int capacityOfTrack = int.Parse(Console.ReadLine());
            double moneyPerKilometer = double.Parse(Console.ReadLine());

            int maxPossibleRunners = Math.Min(runnersToParticipate, days * capacityOfTrack);
            ulong totalKilometers = 1UL * (ulong)maxPossibleRunners * (ulong)avarageLapsPerRunner * (ulong)lengthOfTrack / 1000;
            double moneyRaised = moneyPerKilometer * totalKilometers;

            Console.WriteLine($"Money raised: {moneyRaised:F2}");
        }
    }
}

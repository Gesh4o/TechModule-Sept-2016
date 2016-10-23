namespace _04.RoliTheCoder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class RoliTheCoderName
    {
        static void Main(string[] args)
        {
            List<Event> events = new List<Event>();
            string input = Console.ReadLine();

            while (input != "Time for Code")
            {
                string[] inputArgs = input.Split(new char[] { ' '}, StringSplitOptions.RemoveEmptyEntries);
                string id = inputArgs[0];
                string name = inputArgs[1];
                string[] participants = inputArgs.Skip(2).ToArray();

                if (!name.StartsWith("#") || (events.Any(e => e.ID == id && e.Name != name.TrimStart('#'))))
                {
                    input = Console.ReadLine();
                    continue;
                }

                if (events.Any(e => e.ID == id))
                {
                    Event ev = events.FirstOrDefault(e => e.ID == id);

                    foreach (var participant in participants)
                    {
                        ev.Participants.Add(participant);
                    }
                }
                else
                {
                    events.Add(new Event() { ID = id, Name = name.TrimStart('#'), Participants = new SortedSet<string>(participants) });
                }

                input = Console.ReadLine();
            }

            foreach (Event e in events.OrderByDescending(e => e.Participants.Count).ThenBy(e => e.Name))
            {
                Console.WriteLine($"{e.Name} - {e.Participants.Count}");
                foreach (string participant in e.Participants)
                {
                    Console.WriteLine(participant);
                }
            }
        }
    }

    public class Event
    {
        public string ID { get; set; }

        public string Name { get; set; }

        public SortedSet<string> Participants { get; set; }
    }
}

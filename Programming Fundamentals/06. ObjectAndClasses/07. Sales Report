namespace ObjectAndClasses
{
    using System;
    using System.Linq;

    class SalesMain
    {
        static void Main(string[] args)
        {
            int salesCount = int.Parse(Console.ReadLine());
            
            // Create all sales.
            Sale[] sales = new Sale[salesCount];
            for (int i = 0; i < salesCount; i++)
            {
                // For each sale set properties based on the input.
                string[] info = Console.ReadLine().Split();
                Sale sale = new Sale();
                sale.Town = info[0];
                sale.Product = info[1];
                sale.Price = decimal.Parse(info[2]);
                sale.Quantity = decimal.Parse(info[3]);

                sales[i] = sale;
            }
            
            // Group sales by town and sort towns alphabetically.
            string[] townsByName = sales.Select(sale => sale.Town).Distinct().OrderBy(t => t).ToArray();

            // For each town get its sales and get the sum of all sales.
            for (int i = 0; i < townsByName.Length; i++)
            {
                decimal sum = sales.Where(s => s.Town == townsByName[i]).Sum(s => s.Price * (decimal)s.Quantity);
                Console.WriteLine($"{townsByName[i]} -> {sum:F2}");
            }

        }
    }

    class Sale
    {
        public string Town { get; set; }

        public string Product { get; set; }

        public decimal Quantity { get; set; }

        public decimal Price { get; set; }
    }

}

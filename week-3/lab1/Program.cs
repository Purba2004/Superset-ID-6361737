using System;
using System.Linq;

namespace lab1
{
    class Program
    {
        static void Main()
        {
            using (var context = new AppDbContext())
            {
                if (!context.Categories.Any())
                {
                    var electronics = new Category { Name = "Electronics" };
                    var groceries = new Category { Name = "Groceries" };

                    context.Categories.AddRange(electronics, groceries);
                    context.Products.AddRange(
                        new Product { Name = "Laptop", Quantity = 10, Category = electronics },
                        new Product { Name = "Rice Bag", Quantity = 50, Category = groceries }
                    );

                    context.SaveChanges();
                }

                var products = context.Products
                    .Select(p => new { p.Name, p.Quantity, Category = p.Category.Name })
                    .ToList();

                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name} ({p.Category}): {p.Quantity} in stock");
                }
            }
        }
    }
}

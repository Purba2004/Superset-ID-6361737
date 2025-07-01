using lab2;
using System;
using System.Linq;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                if (!context.Categories.Any())
                {
                    var cat1 = new Category { Name = "Electronics" };
                    var cat2 = new Category { Name = "Groceries" };

                    context.Categories.AddRange(cat1, cat2);
                    context.Products.AddRange(
                        new Product { Name = "Laptop", Price = 999.99m, Category = cat1 },
                        new Product { Name = "Rice", Price = 40.50m, Category = cat2 }
                    );
                    context.SaveChanges();
                }

                var products = context.Products
                    .Select(p => new { p.Name, p.Price, Category = p.Category.Name })
                    .ToList();

                foreach (var p in products)
                {
                    Console.WriteLine($"{p.Name} - {p.Category} - Rs.{p.Price}");
                }
            }
        }
    }
}

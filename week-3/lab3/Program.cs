using lab2; // Namespace where AppDbContext, Product, Category exist

class Program
{
    static void Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure DB is created (optional if migrations already ran)
        context.Database.EnsureCreated();

        // Check if data already exists
        if (!context.Categories.Any())
        {
            // Sample categories
            var electronics = new Category { Name = "Electronics" };
            var clothing = new Category { Name = "Clothing" };
            var groceries = new Category { Name = "Groceries" };

            context.Categories.AddRange(electronics, clothing, groceries);
            context.SaveChanges();

            // Sample products
            var products = new List<Product>
            {
                new Product { Name = "Laptop", Price = 45000m, CategoryId = electronics.Id },
                new Product { Name = "T-Shirt", Price = 499m, CategoryId = clothing.Id },
                new Product { Name = "Apples", Price = 150m, CategoryId = groceries.Id },
            };

            context.Products.AddRange(products);
            context.SaveChanges();

            Console.WriteLine("Database create!\n Sample data seeded.");
        }
        else
        {
            Console.WriteLine(" Data already exists.");
        }
    }
}

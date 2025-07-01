using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using lab2;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Print which database is being used
        Console.WriteLine("Using Database: " + context.Database.GetDbConnection().Database);

        // Retrieve all products with their categories
        Console.WriteLine("\nAll Products:");
        var products = await context.Products
            .Include(p => p.Category)
            .ToListAsync();

        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Category?.Name} - Rs.{p.Price}");

        // Find product by ID = 1
        Console.WriteLine("\nFind by ID (Product with ID = 1):");
        var product = await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Id == 1);

        Console.WriteLine($"Found: {product?.Name ?? "No product found"}");

        // First product with price > 50,000
        Console.WriteLine("\nFirst Product with Price > Rs.50,000:");
        var expensive = await context.Products
            .Include(p => p.Category)
            .FirstOrDefaultAsync(p => p.Price > 50000);

        Console.WriteLine($"Expensive: {expensive?.Name ?? "No expensive product found"}");
    }
}

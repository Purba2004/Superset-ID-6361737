using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab2; // Reference to the shared AppDbContext, Product, Category

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Update a Product: "Laptop" to new price 70000
        var product = await context.Products.FirstOrDefaultAsync(p => p.Name == "Laptop");
        if (product != null)
        {
            product.Price = 70000;
            await context.SaveChangesAsync();
            Console.WriteLine($"Updated: {product.Name} price to Rs.{product.Price}");
        }
        else
        {
            Console.WriteLine("Product 'Laptop' not found for update.");
        }

        // Delete a Product: "Rice Bag"
        var toDelete = await context.Products.FirstOrDefaultAsync(p => p.Name == "Rice Bag");
        if (toDelete != null)
        {
            context.Products.Remove(toDelete);
            await context.SaveChangesAsync();
            Console.WriteLine($"Deleted: {toDelete.Name}");
        }
        else
        {
            Console.WriteLine("Product 'Rice Bag' not found for deletion.");
        }

        // Optional: Print all remaining products
        Console.WriteLine("\nRemaining Products:");
        var products = await context.Products.Include(p => p.Category).ToListAsync();
        foreach (var p in products)
        {
            Console.WriteLine($"{p.Name} - {p.Category?.Name} - Rs.{p.Price}");
        }
    }
}

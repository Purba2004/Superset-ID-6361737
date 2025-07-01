using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab2;

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // 1. Filter and Sort: Products with price > 1000, ordered by price descending
        Console.WriteLine("Filtered & Sorted Products (Price > 1000):");
        var filtered = await context.Products
            .Include(p => p.Category)
            .Where(p => p.Price > 1000)
            .OrderByDescending(p => p.Price)
            .ToListAsync();

        foreach (var product in filtered)
        {
            Console.WriteLine($"{product.Name} - {product.Category?.Name} - Rs.{product.Price}");
        }

        // 2. Project into DTOs: Name and Price only
        Console.WriteLine("\nProduct DTOs (Name and Price only):");
        var productDTOs = await context.Products
            .Select(p => new ProductDto
            {
                Name = p.Name,
                Price = p.Price
            })
            .ToListAsync();

        foreach (var dto in productDTOs)
        {
            Console.WriteLine($"{dto.Name} - Rs.{dto.Price}");
        }
    }
}

// DTO class for projection
public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

using System;
using System.Threading.Tasks;
using lab2;  // Make sure this matches the namespace of AppDbContext

class Program
{
    static async Task Main(string[] args)
    {
        using var context = new AppDbContext();

        // Ensure database is created
        bool created = await context.Database.EnsureCreatedAsync();

        if (created)
        {
            Console.WriteLine(" Database created successfully.");
        }
        else
        {
            Console.WriteLine(" Database already exists.");
        }
    }
}

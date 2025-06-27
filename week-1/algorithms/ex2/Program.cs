using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    public int ProductId;
    public string ProductName;
    public string Category;

    public Product(int productId, string productName, string category)
    {
        ProductId = productId;
        ProductName = productName;
        Category = category;
    }

    public override string ToString()
    {
        return $"[{ProductId}, {ProductName}, {Category}]";
    }
}

class Program
{
    // Linear Search by ID
    public static Product LinearSearchById(List<Product> products, int targetId)
    {
        foreach (var product in products)
        {
            if (product.ProductId == targetId)
            {
                return product;
            }
        }
        return null;
    }

    // Binary Search by ID
    public static Product BinarySearchById(List<Product> products, int targetId)
    {
        int left = 0;
        int right = products.Count - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            Product midProduct = products[mid];

            if (midProduct.ProductId == targetId)
            {
                return midProduct;
            }
            else if (midProduct.ProductId < targetId)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return null;
    }

    // Search by name
    public static List<Product> SearchByName(List<Product> products, string name)
    {
        return products.Where(p => p.ProductName.Equals(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    // Search by category
    public static List<Product> SearchByCategory(List<Product> products, string category)
    {
        return products.Where(p => p.Category.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
    }

    static void Main()
    {
        var products = new List<Product>
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Shampoo", "Personal Care"),
            new Product(150, "Mobile Phone", "Electronics"),
            new Product(302, "Notebook", "Stationery"),
            new Product(180, "Smart Watch", "Wearable")
        };

        while (true)
        {
            Console.WriteLine("\n E-commerce Product Search ");
            Console.WriteLine("1. View Products");
            Console.WriteLine("2. Search by Product ID (Linear Search)");
            Console.WriteLine("3. Search by Product ID (Binary Search)");
            Console.WriteLine("4. Search by Product Name");
            Console.WriteLine("5. Search by Category");
            Console.WriteLine("6. Add New Product");
            Console.WriteLine("7. Exit");

            Console.Write("Enter your choice: ");
            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("Invalid input.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    Console.WriteLine("\n Product List ");
                    foreach (var p in products)
                    {
                        Console.WriteLine(p);
                    }
                    break;

                case 2:
                    Console.Write("Enter Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int idLinear))
                    {
                        var resultLinear = LinearSearchById(products, idLinear);
                        Console.WriteLine(resultLinear != null ? $"Product Found: {resultLinear}" : "Product not found.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case 3:
                    Console.Write("Enter Product ID: ");
                    if (int.TryParse(Console.ReadLine(), out int idBinary))
                    {
                        var sortedById = products.OrderBy(p => p.ProductId).ToList();
                        var resultBinary = BinarySearchById(sortedById, idBinary);
                        Console.WriteLine(resultBinary != null ? $"Product Found: {resultBinary}" : "Product not found.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid input.");
                    }
                    break;

                case 4:
                    Console.Write("Enter Product Name: ");
                    string name = Console.ReadLine();
                    var resultsByName = SearchByName(products, name);
                    if (resultsByName.Count == 0)
                    {
                        Console.WriteLine($"No products found with name: {name}");
                    }
                    else
                    {
                        Console.WriteLine("Products Found:");
                        foreach (var p in resultsByName)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;

                case 5:
                    Console.Write("Enter Category: ");
                    string category = Console.ReadLine();
                    var resultsByCategory = SearchByCategory(products, category);
                    if (resultsByCategory.Count == 0)
                    {
                        Console.WriteLine($"No products found in category: {category}");
                    }
                    else
                    {
                        Console.WriteLine("Products Found:");
                        foreach (var p in resultsByCategory)
                        {
                            Console.WriteLine(p);
                        }
                    }
                    break;

                case 6:
                    try
                    {
                        Console.Write("Enter Product ID: ");
                        int newId = int.Parse(Console.ReadLine());
                        Console.Write("Enter Product Name: ");
                        string newName = Console.ReadLine();
                        Console.Write("Enter Category: ");
                        string newCategory = Console.ReadLine();

                        products.Add(new Product(newId, newName, newCategory));
                        Console.WriteLine("Product added successfully.");
                    }
                    catch
                    {
                        Console.WriteLine("Invalid input. Product not added.");
                    }
                    break;

                case 7:
                    Console.WriteLine("Exiting. Thank you!");
                    return;

                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}

import java.util.ArrayList;
import java.util.Arrays;
import java.util.Comparator;
import java.util.List;
import java.util.Scanner;

public class ex2 {

    static class Product {
        int productId;
        String productName;
        String category;

        Product(int productId, String productName, String category) {
            this.productId = productId;
            this.productName = productName;
            this.category = category;
        }

        public String toString() {
            return "[" + productId + ", " + productName + ", " + category + "]";
        }
    }

    // Linear Search by ID
    public static Product linearSearchById(List<Product> products, int targetId) {
        for (Product product : products) {
            if (product.productId == targetId) {
                return product;
            }
        }
        return null;
    }

    // Binary Search by ID
    public static Product binarySearchById(List<Product> products, int targetId) {
        int left = 0;
        int right = products.size() - 1;

        while (left <= right) {
            int mid = left + (right - left) / 2;
            Product midProduct = products.get(mid);
            if (midProduct.productId == targetId) {
                return midProduct;
            } else if (midProduct.productId < targetId) {
                left = mid + 1;
            } else {
                right = mid - 1;
            }
        }
        return null;
    }

    // Search by name
    public static List<Product> searchByName(List<Product> products, String name) {
        List<Product> results = new ArrayList<>();
        for (Product product : products) {
            if (product.productName.equalsIgnoreCase(name)) {
                results.add(product);
            }
        }
        return results;
    }

    // Search by category
    public static List<Product> searchByCategory(List<Product> products, String category) {
        List<Product> results = new ArrayList<>();
        for (Product product : products) {
            if (product.category.equalsIgnoreCase(category)) {
                results.add(product);
            }
        }
        return results;
    }

    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);

        List<Product> products = new ArrayList<>(Arrays.asList(
                new Product(101, "Laptop", "Electronics"),
                new Product(205, "Shampoo", "Personal Care"),
                new Product(150, "Mobile Phone", "Electronics"),
                new Product(302, "Notebook", "Stationery"),
                new Product(180, "Smart Watch", "Wearable")));

        while (true) {
            System.out.println("\n E-commerce Product Search ");
            System.out.println("1. View Products");
            System.out.println("2. Search by Product ID (Linear Search)");
            System.out.println("3. Search by Product ID (Binary Search)");
            System.out.println("4. Search by Product Name");
            System.out.println("5. Search by Category");
            System.out.println("6. Add New Product");
            System.out.println("7. Exit");

            System.out.print("Enter your choice: ");
            int choice = 0;
            try {
                choice = Integer.parseInt(scanner.nextLine());
            } catch (Exception e) {
                System.out.println("Invalid input.");
                continue;
            }

            switch (choice) {
                case 1:
                    System.out.println("\n Product List ");
                    for (Product p : products) {
                        System.out.println(p);
                    }
                    break;

                case 2:
                    System.out.print("Enter Product ID: ");
                    int idLinear = Integer.parseInt(scanner.nextLine());
                    Product resultLinear = linearSearchById(products, idLinear);
                    System.out.println(resultLinear != null ? "Product Found: " + resultLinear : "Product not found.");
                    break;

                case 3:
                    System.out.print("Enter Product ID: ");
                    int idBinary = Integer.parseInt(scanner.nextLine());
                    List<Product> sortedById = new ArrayList<>(products);
                    sortedById.sort(Comparator.comparingInt(p -> p.productId));
                    Product resultBinary = binarySearchById(sortedById, idBinary);
                    System.out.println(resultBinary != null ? "Product Found: " + resultBinary : "Product not found.");
                    break;

                case 4:
                    System.out.print("Enter Product Name: ");
                    String name = scanner.nextLine();
                    List<Product> resultsByName = searchByName(products, name);
                    if (resultsByName.isEmpty()) {
                        System.out.println("No products found with name: " + name);
                    } else {
                        System.out.println("Products Found:");
                        for (Product p : resultsByName) {
                            System.out.println(p);
                        }
                    }
                    break;

                case 5:
                    System.out.print("Enter Category: ");
                    String category = scanner.nextLine();
                    List<Product> resultsByCategory = searchByCategory(products, category);
                    if (resultsByCategory.isEmpty()) {
                        System.out.println("No products found in category: " + category);
                    } else {
                        System.out.println("Products Found:");
                        for (Product p : resultsByCategory) {
                            System.out.println(p);
                        }
                    }
                    break;

                case 6:
                    try {
                        System.out.print("Enter Product ID: ");
                        int newId = Integer.parseInt(scanner.nextLine());
                        System.out.print("Enter Product Name: ");
                        String newName = scanner.nextLine();
                        System.out.print("Enter Category: ");
                        String newCategory = scanner.nextLine();
                        products.add(new Product(newId, newName, newCategory));
                        System.out.println("Product added successfully.");
                    } catch (Exception e) {
                        System.out.println("Invalid input. Product not added.");
                    }
                    break;

                case 7:
                    System.out.println("Exiting. Thank you!");
                    scanner.close();
                    return;

                default:
                    System.out.println("Invalid choice.");
            }
        }
    }
}

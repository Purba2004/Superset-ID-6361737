Lab 1: Define Models
-----------------------------------------------------------------------
- Created models: Product and Category
- Product has: Id, Name, Price, Category
- Category has: Id, Name, List of Products
- Set up basic one-to-many relationship

=======================================================================
Lab 2: Configure DbContext and Database Connection
-----------------------------------------------------------------------
- Created AppDbContext class using EF Core
- Registered DbSets: Products and Categories
- Configured connection string for LocalDB
- Used Fluent API or data annotations if needed

=======================================================================
Lab 3: Create and Apply Migrations using EF Core CLI
-----------------------------------------------------------------------
- Installed EF Core CLI using `dotnet tool install --global dotnet-ef`
- Created initial migration using:
    dotnet ef migrations add InitialCreate
- Applied migration using:
    dotnet ef database update
- Verified tables created in SQL Server

=======================================================================
Lab 4: Insert Initial Data into Database
-----------------------------------------------------------------------
- Inserted data using `AddRangeAsync` and `SaveChangesAsync`
- Added categories: "Electronics", "Groceries"
- Added products: "Laptop", "Rice Bag" with respective categories
- Confirmed data insertion in SSMS

=======================================================================
Lab 5: Retrieve Data from Database
-----------------------------------------------------------------------
- Retrieved all products with category and price
- Used `FindAsync` to fetch product by ID
- Used `FirstOrDefaultAsync` to fetch expensive product (price > 50,000)
- Displayed results in console

=======================================================================
Lab 6: Update and Delete Records
-----------------------------------------------------------------------
- Updated product "Laptop" price to 70,000
- Deleted product "Rice Bag"
- Used `FirstOrDefaultAsync`, modified entity, and called `SaveChangesAsync`
- Displayed remaining products in console

=======================================================================
Lab 7: LINQ Queries - Filtering, Sorting, Projection
-----------------------------------------------------------------------
- Filtered products with price > 1,000 and sorted by price (descending)
- Projected product name and price into DTOs using `Select`
- Displayed filtered list and DTO list in console

=======================================================================
Folder Structure (Example):
-----------------------------------------------------------------------
Solution/
│
├── lab2/      → Contains models and AppDbContext
├── lab3/      → Handles migration logic
├── lab4/      → Inserts initial data
├── lab5/      → Reads and displays data
├── lab6/      → Updates and deletes records
├── lab7/      → LINQ queries for reporting

=======================================================================
Requirements:
-----------------------------------------------------------------------
- .NET SDK 8.0+
- Visual Studio 2022 or later
- Microsoft SQL Server (LocalDB)
- Microsoft.EntityFrameworkCore.*

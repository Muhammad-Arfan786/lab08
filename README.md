# Books Management System

A beginner-friendly ASP.NET Core Razor Pages application for managing a product catalogue. It completes the supplied Create, Details, and Delete pages with the missing application components.

## Features

- List all products
- Add products with an image
- View product details
- Edit product information and optionally replace its image
- Delete products and their stored images
- Store title, description, price, quantity, and active/inactive status
- Repository pattern for database operations
- SQLite database created automatically on first run
- Server-side validation and image extension/size checks

## Requirements

- .NET 8 SDK
- Internet access on first run to restore NuGet packages and load Bootstrap/jQuery CDN resources

## Run locally

1. Clone this repository.
2. Open a terminal in the folder containing Books_Management_System.csproj.
3. Run `dotnet restore`.
4. Run `dotnet run`.
5. Open the local URL printed in the terminal and choose Products or Add Product.

## Database and images

- SQLite database: books-management.db (created automatically in the application working directory).
- Product images: wwwroot/uploads/products/.
- Supported image formats: JPG, JPEG, PNG, WEBP; maximum 5 MB each.
- Database and uploaded images are runtime data and are excluded from Git.

## Main structure

- Data: ApplicationDbContext and ProductRepository
- Models: Product
- Services: ProductImageService
- Pages/Products: Index, Create, Details, Edit, Delete (each with Razor page model)
- Pages/Shared: application layout and validation scripts
- wwwroot: CSS and uploaded product images
- Program.cs: application setup and dependency registration

## Product status

- A = Active
- I = Inactive

# Project Management System (PMS)

A simple Project Management System built with ASP.NET Core Razor Pages, C#, Entity Framework Core, SQLite, and Bootstrap. The project uses the Repository Pattern to keep database access separate from page logic.

## Features

- Create, view, edit, and delete projects (CRUD)
- Store project name and description
- Track project start date and end date
- Manage project budget
- Assign a project manager
- Set project priority: Low, Medium, High, Critical
- Track project status: Planning, In Progress, On Hold, Completed, Cancelled
- Validate required fields and ensure the end date is not earlier than the start date
- SQLite database is created automatically on first run

## Requirements

- .NET 8 SDK
- Internet connection on first run for NuGet restore and Bootstrap CDN assets

## Run locally

1. Clone or download this repository.
2. Open a terminal in the folder containing Project_Management_System.csproj.
3. Run `dotnet restore`.
4. Run `dotnet run`.
5. Open the local URL printed in the terminal. Use Dashboard, Projects, or Create Project.

## Database

The application uses SQLite. The database file `project-management.db` is created automatically in the application working directory on first run. The database file is excluded from Git.

## Architecture

- **Models/Project.cs** — project entity and validation rules.
- **Data/ApplicationDbContext.cs** — Entity Framework Core database context.
- **Data/ProjectRepository.cs** — repository pattern for project CRUD operations.
- **Pages/Projects/** — Razor Pages for listing, creating, viewing, editing, and deleting projects.
- **Program.cs** — dependency injection, database setup, and application pipeline.

## Project status values

Planning, In Progress, On Hold, Completed, Cancelled.

## Priority values

Low, Medium, High, Critical.

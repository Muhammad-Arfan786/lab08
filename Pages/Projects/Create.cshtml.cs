using Project_Management_System.Data;
using Project_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_Management_System.Pages.Projects
{
    public class CreateModel : PageModel
    {
        private readonly ProjectRepository _repository;
        public CreateModel(ProjectRepository repository) => _repository = repository;
        [BindProperty] public Project Project { get; set; } = new();

        public void OnGet()
        {
            Project.StartDate = DateTime.Today;
            Project.EndDate = DateTime.Today.AddDays(30);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid) return Page();
            await _repository.CreateAsync(Project);
            TempData["Success"] = "Project created successfully.";
            return RedirectToPage("Index");
        }
    }
}
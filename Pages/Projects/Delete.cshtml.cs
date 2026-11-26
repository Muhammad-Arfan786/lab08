using Project_Management_System.Data;
using Project_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_Management_System.Pages.Projects
{
    public class DeleteModel : PageModel
    {
        private readonly ProjectRepository _repository;
        public DeleteModel(ProjectRepository repository) => _repository = repository;
        public Project Project { get; private set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return NotFound();
            Project = project;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!await _repository.DeleteAsync(id)) return NotFound();
            TempData["Success"] = "Project deleted successfully.";
            return RedirectToPage("Index");
        }
    }
}
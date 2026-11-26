using Project_Management_System.Data;
using Project_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_Management_System.Pages.Projects
{
    public class EditModel : PageModel
    {
        private readonly ProjectRepository _repository;
        public EditModel(ProjectRepository repository) => _repository = repository;
        [BindProperty] public Project Project { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var project = await _repository.GetByIdAsync(id);
            if (project == null) return NotFound();
            Project = project;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != Project.Id) return BadRequest();
            if (!ModelState.IsValid) return Page();
            if (!await _repository.UpdateAsync(Project)) return NotFound();
            TempData["Success"] = "Project updated successfully.";
            return RedirectToPage("Index");
        }
    }
}
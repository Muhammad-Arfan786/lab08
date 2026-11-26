using Project_Management_System.Data;
using Project_Management_System.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Project_Management_System.Pages.Projects
{
    public class IndexModel : PageModel
    {
        private readonly ProjectRepository _repository;
        public IndexModel(ProjectRepository repository) => _repository = repository;
        public List<Project> Projects { get; private set; } = new();

        public async Task OnGetAsync()
        {
            Projects = await _repository.GetAllAsync();
        }
    }
}
using Project_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Project_Management_System.Data
{
    // Repository Pattern: all project database operations are kept in this class.
    public class ProjectRepository
    {
        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<List<Project>> GetAllAsync() =>
            _context.Projects.AsNoTracking()
                .OrderByDescending(p => p.Id).ToListAsync();

        public Task<Project?> GetByIdAsync(int id) =>
            _context.Projects.FirstOrDefaultAsync(p => p.Id == id);

        public async Task CreateAsync(Project project)
        {
            _context.Projects.Add(project);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdateAsync(Project project)
        {
            var existing = await _context.Projects.FindAsync(project.Id);
            if (existing == null) return false;

            existing.Name = project.Name;
            existing.Description = project.Description;
            existing.StartDate = project.StartDate;
            existing.EndDate = project.EndDate;
            existing.Budget = project.Budget;
            existing.Status = project.Status;
            existing.Priority = project.Priority;
            existing.ProjectManager = project.ProjectManager;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var project = await _context.Projects.FindAsync(id);
            if (project == null) return false;

            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
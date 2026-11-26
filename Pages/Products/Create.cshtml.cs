using Books_Management_System.Data;
using Books_Management_System.Models;
using Books_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books_Management_System.Pages.Products
{
    public class CreateModel : PageModel
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageService _images;

        public CreateModel(ProductRepository repository, ProductImageService images)
        {
            _repository = repository;
            _images = images;
        }

        [BindProperty]
        public Product Product { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public void OnGet()
        {
            Product.status = "A";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var error = _images.Validate(ImageFile);
            if (error != null)
                ModelState.AddModelError(nameof(ImageFile), error);

            if (!ModelState.IsValid)
                return Page();

            var imagePath = await _images.SaveAsync(ImageFile!);
            try
            {
                Product.image = imagePath;
                await _repository.CreateAsync(Product);
                TempData["Success"] = "Product created successfully.";
                return RedirectToPage("Index");
            }
            catch
            {
                _images.Delete(imagePath);
                throw;
            }
        }
    }
}

using Books_Management_System.Data;
using Books_Management_System.Models;
using Books_Management_System.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Books_Management_System.Pages.Products
{
    public class EditModel : PageModel
    {
        private readonly ProductRepository _repository;
        private readonly ProductImageService _images;

        public EditModel(ProductRepository repository, ProductImageService images)
        {
            _repository = repository;
            _images = images;
        }

        [BindProperty]
        public Product Product { get; set; } = new();

        [BindProperty]
        public IFormFile? ImageFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            var product = await _repository.GetByIdAsync(id);
            if (product == null) return NotFound();
            Product = product;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (id != Product.Id) return BadRequest();

            if (ImageFile != null && ImageFile.Length > 0)
            {
                var error = _images.Validate(ImageFile);
                if (error != null) ModelState.AddModelError(nameof(ImageFile), error);
            }

            if (!ModelState.IsValid) return Page();

            var existing = await _repository.GetByIdAsync(id);
            if (existing == null) return NotFound();

            var oldImage = existing.image;
            string? newImage = null;
            if (ImageFile != null && ImageFile.Length > 0)
                newImage = await _images.SaveAsync(ImageFile);

            Product.image = newImage ?? oldImage;

            try
            {
                if (!await _repository.UpdateAsync(Product))
                {
                    if (newImage != null) _images.Delete(newImage);
                    return NotFound();
                }

                if (newImage != null) _images.Delete(oldImage);
                TempData["Success"] = "Product updated successfully.";
                return RedirectToPage("Index");
            }
            catch
            {
                if (newImage != null) _images.Delete(newImage);
                throw;
            }
        }
    }
}

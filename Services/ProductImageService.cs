namespace Books_Management_System.Services
{
    public class ProductImageService
    {
        private readonly IWebHostEnvironment _environment;
        private const long MaxFileSize = 5 * 1024 * 1024;
        private static readonly HashSet<string> AllowedExtensions =
            new(StringComparer.OrdinalIgnoreCase) { ".jpg", ".jpeg", ".png", ".webp" };

        public ProductImageService(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        public string? Validate(IFormFile? file)
        {
            if (file == null || file.Length == 0)
                return "Please select an image.";

            if (file.Length > MaxFileSize)
                return "Image size must not exceed 5 MB.";

            var extension = Path.GetExtension(file.FileName);
            if (string.IsNullOrWhiteSpace(extension) || !AllowedExtensions.Contains(extension))
                return "Only JPG, JPEG, PNG, and WEBP images are allowed.";

            return null;
        }

        public async Task<string> SaveAsync(IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
            var folder = Path.Combine(_environment.WebRootPath, "uploads", "products");
            Directory.CreateDirectory(folder);

            var fileName = $"{Guid.NewGuid():N}{extension}";
            var fullPath = Path.Combine(folder, fileName);

            await using var stream = new FileStream(fullPath, FileMode.CreateNew);
            await file.CopyToAsync(stream);

            return Path.Combine("uploads", "products", fileName).Replace("\\", "/");
        }

        public void Delete(string? relativePath)
        {
            if (string.IsNullOrWhiteSpace(relativePath))
                return;

            var normalized = relativePath.Replace('/', Path.DirectorySeparatorChar);
            var root = Path.GetFullPath(Path.Combine(_environment.WebRootPath, "uploads", "products"));
            var fullPath = Path.GetFullPath(Path.Combine(_environment.WebRootPath, normalized));

            // Only delete files inside the product upload directory.
            if (!fullPath.StartsWith(root + Path.DirectorySeparatorChar, StringComparison.OrdinalIgnoreCase))
                return;

            if (File.Exists(fullPath))
                File.Delete(fullPath);
        }
    }
}

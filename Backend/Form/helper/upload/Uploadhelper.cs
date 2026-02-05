namespace Form.helper.upload
{
    public class Uploadhelper
    {
        public async Task<string> SaveFileAsync(
    IFormFile file,
    string folderName,
    long maxSize,
    string[] allowedExtensions)
        {
            if (file == null || file.Length == 0)
                throw new Exception("File is empty");

            var extension = Path.GetExtension(file.FileName).ToLower();

            if (!allowedExtensions.Contains(extension))
                throw new Exception("Invalid file type");

            if (file.Length > maxSize)
                throw new Exception("File size exceeded");

            var uploadsFolder = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                "uploads",
                folderName
            );

            if (!Directory.Exists(uploadsFolder))
                Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{Guid.NewGuid()}{extension}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            // Path saved in DB
            return $"/uploads/{folderName}/{fileName}";
        }
        
    }

}


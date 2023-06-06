using EvaraWebApp.Models;

namespace EvaraWebApp.Extensions;

public static class FileExtension
{
    public static bool CheckType(this IFormFile file, string type)
    {
        return file.ContentType.Contains(type);
    }
    public static bool CheckSize(this IFormFile file, double kb)
    {
        return file.Length / 1024 > kb;
    }
    public static async Task<string> UploadAsync(this IFormFile file, params string[] folders)
    {
        string guid = Guid.NewGuid().ToString();
        string newFileName = guid + file.FileName;
        //assets images slider 
        string pathFolder = Path.Combine(folders); // assets/images/slider
        string path = Path.Combine(pathFolder,newFileName); // assets/images/slider/sdkkdad.jpg
        using (FileStream fileStream = new FileStream(path, FileMode.CreateNew))
        {
            await file.CopyToAsync(fileStream);
        }
        return newFileName;
    }
}

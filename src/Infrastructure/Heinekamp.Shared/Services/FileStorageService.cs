using Heinekamp.Application.Services;
using Microsoft.AspNetCore.Hosting;

namespace Heinekamp.Shared.Services;

public class FileStorageService : IFileStorageService
{
    private readonly string _fileStoragePath;

    public FileStorageService(IWebHostEnvironment environment)
    {
        _fileStoragePath = Path.Combine(environment.WebRootPath, "Attachments");

        if (!Directory.Exists(_fileStoragePath))
        {
            Directory.CreateDirectory(_fileStoragePath);
        }
    }

    public async Task<string> SaveFileAsync(string fileName, byte[] content)
    {
        var filePath = Path.Combine(_fileStoragePath, fileName);

        await File.WriteAllBytesAsync(filePath, content);

        return filePath;
    }

    public async Task<byte[]> GetFileAsync(string fileName)
    {
        var filePath = Path.Combine(_fileStoragePath, fileName);

        return await File.ReadAllBytesAsync(filePath);
    }

    public Stream GetFileStreamAsync(string fileName)
    {
        var filePath = Path.Combine(_fileStoragePath, fileName);

        if (!File.Exists(filePath))
        {
            return null;
        }

        var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);

        return stream;
    }
}

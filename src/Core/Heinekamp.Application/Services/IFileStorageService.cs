using System.Threading.Tasks;

namespace Heinekamp.Application.Services
{
    public interface IFileStorageService
    {
        Task<string> SaveFileAsync(string fileName, byte[] content);

        Task<byte[]> GetFileAsync(string fileName);
    }
}
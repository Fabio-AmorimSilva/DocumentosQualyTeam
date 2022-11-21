
using Microsoft.AspNetCore.Http;

namespace Processos.Dominio.Interfaces.Storage
{
    public interface IFileStorage
    {
        Task<bool> UploadFile(IFormFile file, string filePath);
        Task<bool> RemoveFile(string filePath);
        Task<bool> IfNotExistCreateDirectory(string directory);
        FileStream GetFile(string filePath);
    }
}

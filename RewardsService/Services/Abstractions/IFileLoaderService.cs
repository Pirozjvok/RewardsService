using System.IO;

namespace RewardsService.Services.Abstractions
{
    public interface IFileLoaderService
    {
        Task<Stream?> GetFileStreamAsync(Guid id);
        Task<Stream?> GetFileStreamAsync(string fileName);
        Task<FileInformation?> GetFileInfoAsync(string fileName);
        Task<FileInformation?> GetFileInfoAsync(Guid id);
        Task<Guid> UploadFileAsync(Stream file, string filename, string? applicationHeader);
    }
}

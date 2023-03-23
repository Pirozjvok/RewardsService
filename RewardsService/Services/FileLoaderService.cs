using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileSystemGlobbing.Abstractions;
using RewardsService.DataBase;
using RewardsService.Models;
using RewardsService.Services.Abstractions;

namespace RewardsService.Services
{
    public class FileLoaderService : IFileLoaderService
    {
        private const string DefaultPath = "wwwroot/files";
        private readonly FilesContext _context;

        private readonly IConfiguration _configuration;

        private string FilePath => _configuration["FileStore:Path"] ?? DefaultPath;
        public FileLoaderService(FilesContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }
        public async Task<Guid> UploadFileAsync(Stream file, string filename, string? applicationHeader)
        {
            FileModel fm = new FileModel();
            fm.Name = filename;
            fm.Id = Guid.NewGuid();
            using FileStream fs = new FileStream($"{FilePath}/{fm.Id}", FileMode.Create, FileAccess.Write);
            await file.CopyToAsync(fs);
            await _context.Files.AddAsync(fm);
            await _context.SaveChangesAsync();
            return fm.Id;
        }

        public async Task<FileInformation?> GetFileInfoAsync(Guid id)
        {
            FileModel? model = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                return null;

            FileInformation info = new FileInformation(model.Id, model.Name);
            return info;
        }

        public async Task<FileInformation?> GetFileInfoAsync(string fileName)
        {
            FileModel? model = await _context.Files.FirstOrDefaultAsync(x => x.Name.ToLower() == fileName.ToLower());
            if (model == null)
                return null;

            FileInformation info = new FileInformation(model.Id, model.Name);
            return info;
        }
        public async Task<Stream?> GetFileStreamAsync(string fileName)
        {
            FileModel? model = await _context.Files.FirstOrDefaultAsync(x => x.Name.ToLower() == fileName.ToLower());
            if (model == null)
                return null;

            string fm = $"{FilePath}/{model.Id}";
            if (!File.Exists(fm))
                return null;

            FileStream fs = new FileStream($"{FilePath}/{model.Id}", FileMode.Open, FileAccess.Read);
            return fs;
        }

        public async Task<Stream?> GetFileStreamAsync(Guid id)
        {
            FileModel? model = await _context.Files.FirstOrDefaultAsync(x => x.Id == id);
            if (model == null)
                return null;

            string fm = $"{FilePath}/{model.Id}";
            if (!File.Exists(fm))
                return null;

            FileStream fs = new FileStream($"{FilePath}/{model.Id}", FileMode.Open, FileAccess.Read);
            return fs;
        }
    }
}

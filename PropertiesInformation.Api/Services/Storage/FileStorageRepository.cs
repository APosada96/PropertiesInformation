
using PropertiesInformation.Domain.Interfaces.Storage;

namespace PropertiesInformation.Api.Services.Storage
{
    public class FileStorageRepository : IFileStorageRepository
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FileStorageRepository(IWebHostEnvironment env, IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> Store(string container, IFormFile file)
        {
            var extension = Path.GetExtension(file.FileName);
            var nameFile = $"{Guid.NewGuid()}{extension}";
            string folder = Path.Combine(env.WebRootPath, container);

            if (!Directory.Exists(folder)) Directory.CreateDirectory(folder);

            string rute = Path.Combine(folder, nameFile);

            using (var memory = new MemoryStream())
            {
                await file.CopyToAsync(memory);
                var content = memory.ToArray();
                await File.WriteAllBytesAsync(rute, content);
            }

            var url = $"{httpContextAccessor.HttpContext!.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            return Path.Combine(url, container, nameFile).Replace("\\", "/");

        }

        public Task Delete(string rute, string container)
        {
            if (string.IsNullOrEmpty(rute))
            {
                return Task.CompletedTask;
            }

            var nameFile = Path.GetFileName(rute);
            var directoryFile = Path.Combine(env.WebRootPath, container, nameFile);

            if (File.Exists(directoryFile)) File.Delete(directoryFile);

            return Task.CompletedTask;

        }
    }
}

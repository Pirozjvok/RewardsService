using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using RewardsService.DTO.Read;
using RewardsService.Services.Abstractions;
using System.Net.Mime;

namespace RewardsService.Controllers
{
    [Route("api/[controller].[action]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly IFileLoaderService _fileService;
        public FilesController(IFileLoaderService fileService)
        {
            _fileService = fileService;
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Get([FromRoute]Guid id)
        {
            FileInformation? finfo = await _fileService.GetFileInfoAsync(id);
            if (finfo == null)
                return NotFound();

            Stream? stream = await _fileService.GetFileStreamAsync(id);

            string? ct;

            if (!new FileExtensionContentTypeProvider().TryGetContentType(finfo.FileName, out ct))
            {
                ct = "application/octet-stream";
            }
            return new FileStreamResult(stream!, ct);
        }

        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile uploadFile)
        {
            Stream stream = uploadFile.OpenReadStream();
            Guid id = await _fileService.UploadFileAsync(stream, uploadFile.FileName, uploadFile.ContentType);
            FileInformation? finfo = await _fileService.GetFileInfoAsync(id);
            if (finfo == null)
                return BadRequest();

            ReadFileInfo readFileInfo = new ReadFileInfo()
            {
                Guid = id,
                Name = finfo.FileName,
                Url = Url.Action("Get", new { id = id }) ?? ""
            };

            return Ok(readFileInfo);
        }
    }
}

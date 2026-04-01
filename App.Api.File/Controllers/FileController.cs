using Microsoft.AspNetCore.Mvc;

namespace App.Api.File.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpGet("{fileName}")]
        public IActionResult GetFile(string fileName)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Uploads", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "image/jpeg");
        }

        [HttpGet("download")]
        public IActionResult Download([FromQuery] string fileName)
        {
            var filePath = Path.Combine(_env.ContentRootPath, "Uploads", fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound();

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

            return File(fileBytes, "application/octet-stream", fileName);
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Dosya yok");

            var uploadsPath = Path.Combine(_env.ContentRootPath, "Uploads");

            if (!Directory.Exists(uploadsPath))
                Directory.CreateDirectory(uploadsPath);

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

            var filePath = Path.Combine(uploadsPath, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok(new { fileName });
        }
    }
}
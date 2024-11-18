using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepository _repository;

        public ImageController(IImageRepository repository)
        {
            _repository = repository;
        }


        [HttpPost("upload")]
        public async Task<IActionResult> UploadImages([FromForm] List<IFormFile> files, [FromForm] int flowerId)
        {
            if (files == null || !files.Any())
                return BadRequest("No files provided");

            var images = new List<Image>();

            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);
                        var base64Image = Convert.ToBase64String(memoryStream.ToArray());

                        images.Add(new Image
                        {
                            Name = file.FileName,
                            Imagebase64 = base64Image,
                            Flower_id = flowerId
                        });
                    }
                }
            }

            await _repository.AddImages(images);

            //return Created("api/Image/upload", new { count = images.Count });
            return Ok(images);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllImagesByFlowerId(int flower_id)
        {
            var images = await _repository.GetImageByFlowerId(flower_id);
            return Ok(images);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteImage(int id)
        {
            await _repository.DeleteImage(id);
            return NoContent();
        }
    }
}

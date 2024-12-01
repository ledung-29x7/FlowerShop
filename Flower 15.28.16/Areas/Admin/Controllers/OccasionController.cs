using AutoMapper;
using Flower.Areas.Admin.Models;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccasionController : ControllerBase
    {
        private readonly IOccasionRepository _occasionRepository;
        private readonly IMapper _mapper;

        public OccasionController(IOccasionRepository occasionRepository, IMapper mapper)
        {
            _occasionRepository = occasionRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-occasion")]
        public async Task<IActionResult> CreateOccasion([FromBody] OccasionDto request)
        {
            var occasion = _mapper.Map<Occasion>(request);
            await _occasionRepository.CreateOccasion(occasion);

            return Ok("Occasion created successfully.");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllOccasions()
        {
            var occasions = await _occasionRepository.GetOccasion();
            return Ok(occasions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOccasionById(int id)
        {
            var occasion = await _occasionRepository.GetOccasionById(id);
            if (occasion == null)
                return NotFound("Occasion not found");

            return Ok(occasion);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOccasion(int id, [FromBody] UpdateOccasionDto occasionsDto)
        {
            if (id != occasionsDto.OccasionId)
                return BadRequest("Occasion ID mismatch");

            var occasion = await _occasionRepository.GetOccasionById(id);
            if (occasion == null)
                return NotFound("Occasion not found");

            occasion.Name = occasionsDto.Name;
            occasion.Description = occasionsDto.Description;

            await _occasionRepository.UpdateOccasion(occasion);
            return Ok("Update occasion success");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccasion(int id)
        {
            var occasion = await _occasionRepository.GetOccasionById(id);
            if (occasion == null)
                return NotFound("Occasion not found");

            await _occasionRepository.DeleteOccasion(id);
            return Ok("Delete occasion success");
        }


    }
}

using AutoMapper;
using Flower.Areas.Auther.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Manager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlowerController : ControllerBase
    {
        private readonly IFlowerRepository _flowerRepository;
        private readonly IMapper _mapper;

        public FlowerController(IFlowerRepository flowerRepository, IMapper mapper) 
        {
            _flowerRepository = flowerRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFlowers()
        {
            var flowers = await _flowerRepository.GetFlower();
            return Ok(flowers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlowerById(int id)
        {
            var flower = await _flowerRepository.GetFlowerById(id);
            if (flower == null)
                return NotFound("Flower not found");

            return Ok(flower);
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPost]
        public async Task<IActionResult> CreateFlower([FromBody] CreateFlowerDto dto)
        {
            var flower = _mapper.Map<Flowers>(dto);
            await _flowerRepository.CreateFlower(flower);
            return Ok("Create Flower success");
        }

        [Authorize(Roles = "Manager,Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateFlower(int id, [FromBody] UpdateFlowerDto dto)
        {
            if (id != dto.FlowerId)
                return BadRequest("Flower ID mismatch");

            var flower = await _flowerRepository.GetFlowerById(id);
            if (flower == null)
                return NotFound("Flower not found");
            flower = _mapper.Map<Flowers>(dto);
            await _flowerRepository.UpdateFlower(flower);
            return Ok("Update Flower Success");
        }


        [Authorize(Roles = "Manager,Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlower(int id)
        {
            var flowers = await _flowerRepository.GetFlowerById(id);
            if (flowers == null)
                return NotFound("Occasion not found");

            await _flowerRepository.DeleteFlower(id);
            return Ok("Delete Flower Success");
        }

    }
}

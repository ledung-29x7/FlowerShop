using AutoMapper;
using Flower.Areas.Admin.Models;
using Flower.Areas.Dtos;
using Flower.Areas.Manager.Models;
using Flower.DAL.Interfaces;
using Flower.DAL.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Flower.Areas.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;
        private readonly IMapper _mapper;

        public StoreController(IStoreRepository storeRepository, IMapper mapper)
        {
            _storeRepository = storeRepository;
            _mapper = mapper;
        }

        [Authorize(Roles = "Admin")]
        [HttpPost("create-store")]
        public async Task<IActionResult> CreateStore([FromBody] CreateStoreDto request)
        {
            var store = _mapper.Map<Store>(request);
            await _storeRepository.CreateStore(store);

            return Ok("Store created successfully.");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStores()
        {
            var stores = await _storeRepository.GetStores();
            return Ok(stores);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStoreById(int id)
        {
            var store = await _storeRepository.GetStoreById(id);
            if (store == null)
                return NotFound("Store not found");

            return Ok(store);
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStore(int id, [FromBody] UpdateStoreDto dto)
        {
            if (id != dto.Store_id)
                return BadRequest("Flower ID mismatch");

            var store = await _storeRepository.GetStoreById(id);
            if (store == null)
                return NotFound("Flower not found");
            store = _mapper.Map<Store>(dto);
            await _storeRepository.UpdateStore(store);
            return Ok("Update Flower Success");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOccasion(int id)
        {
            var occasion = await _storeRepository.GetStoreById(id);
            if (occasion == null)
                return NotFound("Store not found");

            await _storeRepository.DeleteStore(id);
            return Ok("Delete Store success");
        }

    }
}

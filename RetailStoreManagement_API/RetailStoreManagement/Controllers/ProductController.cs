using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailStoreManagement.DTOs;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _productService = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all products.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductReadDto>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<ProductReadDto>>(products));
        }

        /// <summary>
        /// Retrieves a product by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductReadDto>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null) return NotFound();
            return Ok(_mapper.Map<ProductReadDto>(product));
        }

        /// <summary>
        /// Creates a new product.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<ProductReadDto>> Create(ProductCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var product = _mapper.Map<Product>(dto);
            var created = await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<ProductReadDto>(created));
        }

        /// <summary>
        /// Updates an existing product.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductCreateDto dto)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); // Apply DTO changes to the existing entity
            await _productService.UpdateAsync(existing);
            return NoContent();
        }

        /// <summary>
        /// Deletes a product.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _productService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}

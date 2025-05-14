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
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerService customerService, IMapper mapper)
        {
            _customerService = customerService;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all customers.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerReadDto>>> GetAll()
        {
            var customers = await _customerService.GetAllAsync();
            return Ok(_mapper.Map<IEnumerable<CustomerReadDto>>(customers));
        }

        /// <summary>
        /// Retrieves a customer by ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerReadDto>> GetById(int id)
        {
            var customer = await _customerService.GetByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(_mapper.Map<CustomerReadDto>(customer));
        }

        /// <summary>
        /// Creates a new customer.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<CustomerReadDto>> Create(CustomerCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var customer = _mapper.Map<Customer>(dto);
            var created = await _customerService.AddAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, _mapper.Map<CustomerReadDto>(created));
        }

        /// <summary>
        /// Updates an existing customer.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CustomerCreateDto dto)
        {
            var existing = await _customerService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _mapper.Map(dto, existing); // Apply DTO changes to the existing entity
            await _customerService.UpdateAsync(existing);
            return NoContent();
        }

        /// <summary>
        /// Deletes a customer.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existing = await _customerService.GetByIdAsync(id);
            if (existing == null) return NotFound();

            await _customerService.DeleteAsync(id);
            return NoContent();
        }
    }
}

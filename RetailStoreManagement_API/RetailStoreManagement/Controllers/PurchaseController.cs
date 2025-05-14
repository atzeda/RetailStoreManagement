using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RetailStoreManagement.DTOs;
using RetailStoreManagement.Interfaces;
using RetailStoreManagement.Models;

namespace RetailStoreManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PurchaseController : ControllerBase
    {
        private readonly IPurchaseService _purchaseService;
        private readonly IMapper _mapper;

        public PurchaseController(IPurchaseService service, IMapper mapper)
        {
            _purchaseService = service;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all purchases.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Purchase>>> GetAll()
        {
            var purchases = await _purchaseService.GetAllAsync();
            return Ok(purchases);
        }

        /// <summary>
        /// Creates a new purchase.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Purchase>> Create(PurchaseCreateDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var purchase = new Purchase
            {
                CustomerId = dto.CustomerId,
                PurchaseDate = DateTime.UtcNow,
                Items = dto.Items.Select(i => _mapper.Map<PurchaseItem>(i)).ToList()
            };

            var result = await _purchaseService.AddAsync(purchase);
            return CreatedAtAction(nameof(GetAll), new { id = result.Id }, result);
        }
    }
}
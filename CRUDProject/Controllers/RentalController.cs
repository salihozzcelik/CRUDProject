using CRUDProject.Data;
using CRUDProject.DBContext;
using CRUDProject.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace CRUDProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RentalController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IRentalService _customerService;
        public RentalController(AppDbContext context, IRentalService customerService)
        {
            _context = context;
            _customerService = customerService;
        }


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Rental customer)
        {

            if (customer == null)
            {
                return BadRequest();
            }

            var createdPerson = await _customerService.Create(customer);
            return Ok(createdPerson);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePerson(int id, [FromBody] Rental customer)
        {
            if (customer == null || customer.rental_id != id)
            {
                return BadRequest();
            }

            var updatedPerson = await _customerService.Update(customer);
            if (updatedPerson == null)
            {
                return NotFound();
            }

            return Ok(updatedPerson);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _customerService.Delete(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var person = await _customerService.GetCustomerById(id);
            if (person == null)
            {
                return NotFound();
            }

            return Ok(person);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var persons = await _customerService.GetAllCustomers();
            return Ok(persons);
        }
    }
}

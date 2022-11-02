using Microsoft.AspNetCore.Mvc;
using Shopping.DTO;
using Shopping.Models;
using Shopping.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Shopping.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingController : ControllerBase
    {
        private readonly IRepository _repo;

        public ShoppingController(IRepository repo)
        {
            _repo = repo;
        }
        // GET: api/<ShoppingController>
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            try
            {
                var data = await _repo.GetAllEmployees();
                return Ok(new
                {
                    Success = true,
                    Message = "All employees are returned.",
                    data
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // GET api/<ShoppingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ShoppingController>
        [HttpPost]
        public async Task<IActionResult> Create(Employee employee, Guid empId)
        {
            try
            {
                await _repo.SaveEmployee(employee, empId);
                return Ok(new
                {
                    Success = true,
                    Message = "Employee has been created."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // PUT api/<ShoppingController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(ShopDTO shopDTO, Guid id)
        {
            try
            {
                await _repo.UpdateEmployeeShop(shopDTO, id);
                return Ok(new
                {
                    Success = true,
                    Message = "Shop has been updated."
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, ex.Message);
            }
        }

        // DELETE api/<ShoppingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StreetBroker.Models;
using StreetBroker.Repository;

namespace StreetBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        ICustomerRepository _repo;

        public CustomerController(ICustomerRepository repo)
        {
            _repo = repo;
        }

        // GET api/customer/get
        [HttpGet("get")]
        public IActionResult GetCustomers()
        {
            List<Customer> customers = _repo.GetCustomers();
            return Ok(customers);
        }
    }
}

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
    public class DealerController : ControllerBase
    {
        IDealerRepository _repo;

        public DealerController(IDealerRepository repo)
        {
            _repo = repo;
        }

        // GET api/dealer/get
        [HttpGet("get")]
        public IActionResult GetDealers()
        {
            List<Dealer> dealers = _repo.GetDealers();
            return Ok(dealers);
        }
    }
}

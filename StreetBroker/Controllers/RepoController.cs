using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StreetBroker.Common;
using StreetBroker.Models;
using StreetBroker.Repository;

namespace StreetBroker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepoController : ControllerBase
    {
        IRepoRepository _repo;

        public RepoController(IRepoRepository repo)
        {
            _repo = repo;
        }

        // GET api/repo/get
        [HttpGet("get")]
        public IActionResult GetRepos()
        {
            List<RepoOrder> repoOrders = _repo.GetRepoOrders();
            return Ok(repoOrders);
        }

        // GET api/repo/get/id
        [HttpGet("get/{id}")]
        public IActionResult GetRepoById(int id)
        {
            RepoOrder repoOrder = _repo.GetRepoOrder(id);
            return Ok(repoOrder);
        }

        // POST api/repo/save
        [HttpPost("save")]
        public IActionResult PostRepo(decimal amount, DateTime maturity, decimal interestRate, long customerId, long dealerId)
        {
            string errorMessage =ValidateInputs(amount, maturity, interestRate);
            if (!String.IsNullOrWhiteSpace(errorMessage))
            {
                return BadRequest(errorMessage);
            }

            RepoCalculator repoCalculator = new RepoCalculator(amount, maturity, interestRate);
            RepoOrder repoOrder = new RepoOrder()
            {
                Amount = repoCalculator.GetAmount(),
                CreateDate = DateTime.Now,
                CustomerId = customerId,
                DealerId = dealerId,
                GrossInterestAmount = repoCalculator.GetGrossInterestAmount(),
                InterestRate = repoCalculator.GetInterestRate(),
                GrossInterestRate = repoCalculator.GetGrossInterestRate(),
                Maturity = repoCalculator.GetMaturityDate(),
                NetInterestAmount = repoCalculator.GetNetInterestAmount(),
                OrderStatus = OrderStatus.Waiting,
                RecordStatus = RecordStatus.Active,
                ReturnGrossInterestAmount = repoCalculator.GetReturnGrossAmount(),
                ReturnNetInterestAmount = repoCalculator.GetReturnNetAmount(),
                StartDate = DateTime.Now,
                TaxAmount = repoCalculator.GetTaxAmount(),
                UpdateDate = DateTime.Now
            };

            return Ok(_repo.InsertRepoOrder(repoOrder));
        }

        private static string ValidateInputs(decimal amount, DateTime maturity, decimal interestRate)
        {
            string errorMessage = String.Empty;

            if (amount <= 0)
            {
                errorMessage = String.Format("Amount must be greater than zero. Input value : {0}", amount);
            }
            if (interestRate <= 0)
            {
                errorMessage = String.Format("Interest rate must be greater than zero. Input value : {0}", interestRate);
            }
            if (maturity <= DateTime.Now)
            {
                errorMessage = String.Format("Maturity date must be later than today. Input value : {0}", maturity);
            }

            return errorMessage;
        }

        // DELETE api/repo/delete1
        [HttpDelete("delete")]
        public ActionResult DeleteRepo(int id)
        {
            var status = _repo.DeleteRepoOrder(id);
            if (!status)
            {
                return NotFound();
            }
            return Ok(status);
        }
    }
}
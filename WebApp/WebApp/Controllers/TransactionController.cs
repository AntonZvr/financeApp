using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApp.DAL.RepositoryInterfaces;
using WebApp.Data.DAL.ViewModels;
using WebApp.ServiceInterfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpGet]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult(_transactionService.GetTransactions());
        }

        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return new OkObjectResult(transaction);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransactionViewModel transactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _transactionService.InsertTransaction(transactionDto);

            return CreatedAtAction(nameof(GetById), new { id = transactionDto.TransactionId }, transactionDto);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] TransactionViewModel transactionDto)
        {
            if (id != transactionDto.TransactionId)
            {
                return BadRequest();
            }

            _transactionService.UpdateTransaction(id, transactionDto);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _transactionService.DeleteTransaction(id);

            return new OkResult();
        }

    }



}

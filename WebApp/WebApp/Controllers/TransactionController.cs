using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using WebApp.DAL.Models;
using WebApp.DAL.RepositoryInterfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionsController(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        // GET: api/Transactions
        [HttpGet]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult(_transactionRepository.GetTransactions());
        }

        // GET: api/Transactions/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionRepository.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return new OkObjectResult(transaction);
        }

        // POST: api/Transactions
        [HttpPost]
        public IActionResult Post([FromBody] TransactionDto transactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var transaction = new Transaction
            {
                Type = transactionDto.Type,
                Amount = Math.Round(transactionDto.Amount, 2),
                Date = DateTime.ParseExact(transactionDto.Date, "dd.MM.yy", CultureInfo.InvariantCulture),
                Description = transactionDto.Description
            };

            _transactionRepository.InsertTransaction(transaction);
            _transactionRepository.Save();

            return CreatedAtAction(nameof(GetById), new { id = transaction.TransactionId }, transaction);
        }

        // PUT: api/Transactions/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Transaction transaction)
        {
            if (id != transaction.TransactionId)
            {
                return BadRequest();
            }

            _transactionRepository.UpdateTransaction(transaction);
            _transactionRepository.Save();

            return NoContent();
        }

        // DELETE: api/Transactions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var transaction = _transactionRepository.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }

            _transactionRepository.DeleteTransaction(id);
            _transactionRepository.Save();

            return new OkResult();
        }
    }


}

using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult(_transactionRepository.GetTransactions());
        }

        [HttpPost]
        public IActionResult InsertTransaction([FromBody] Transaction transaction)
        {
            _transactionRepository.InsertTransaction(transaction);
            _transactionRepository.Save();
            return CreatedAtAction(nameof(GetTransactions), new { id = transaction.TransactionId }, transaction);
        }

        // Rest of the methods (PUT, DELETE) will go here.
    }

}

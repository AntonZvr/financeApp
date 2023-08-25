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

        [HttpGet("getAllTransactions")]
        public IActionResult GetTransactions()
        {
            return new OkObjectResult(_transactionService.GetTransactions());
        }

        [HttpGet("getTransactionById/{id}", Name = "Get")]
        public IActionResult GetById(int id)
        {
            var transaction = _transactionService.GetTransactionById(id);
            if (transaction == null)
            {
                return NotFound();
            }
            return new OkObjectResult(transaction);
        }

        [HttpPost("addTransaction")]
        public IActionResult Post([FromBody] TransactionViewModel transactionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _transactionService.InsertTransaction(transactionDto);

            return CreatedAtAction(nameof(GetById), new { id = transactionDto.TransactionId, transactionType = 
                transactionDto.TransactionType}, transactionDto);
        }

        [HttpPut("editTransaction/{id}")]
        public IActionResult Put(int id, [FromBody] TransactionViewModel transactionDto)
        {
            if (id != transactionDto.TransactionId)
            {
                return BadRequest();
            }

            _transactionService.UpdateTransaction(id, transactionDto);

            return NoContent();
        }

        [HttpDelete("deleteTransaction/{id}")]
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

        [HttpGet("DailyReport/{date}")]
        public IActionResult DailyReport(DateTime date)
        {
            var report = _transactionService.GetDailyReport(date);

            if (report == null)
            {
                return NotFound();
            }

            return Ok(report);
        }

        [HttpGet("PeriodReport/{startDate}/{endDate}")]
        public IActionResult PeriodReport(DateTime startDate, DateTime endDate)
        {
            if (startDate > endDate)
            {
                return BadRequest("Start date should be less than the end date");
            }

            var report = _transactionService.GetPeriodReport(startDate, endDate);

            if (report?.Transactions.Count() == 0)
            {
                return NotFound();
            }

            return Ok(report);
        }

    }
}

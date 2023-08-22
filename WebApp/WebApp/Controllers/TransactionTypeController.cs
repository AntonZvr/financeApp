using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApp.Data.DAL.Models;
using WebApp.Service.ServiceInterfaces;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionTypeController : ControllerBase
    {
        private readonly ITransactionTypeService _transactionTypeService;

        public TransactionTypeController(ITransactionTypeService transactionTypeService)
        {
            _transactionTypeService = transactionTypeService;
        }

        // GET: api/TransactionType
        [HttpGet]
        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return _transactionTypeService.GetTransactionTypes();
        }

        // GET: api/TransactionType/5
        [HttpGet("{id}")]
        public ActionResult<TransactionType> GetTransactionType(int id)
        {
            var transactionType = _transactionTypeService.GetTransactionTypeById(id);

            if (transactionType == null)
            {
                return NotFound();
            }

            return transactionType;
        }

        // PUT: api/TransactionType/5
        [HttpPut("{id}")]
        public IActionResult PutTransactionType(int id, TransactionType transactionType)
        {
            if (id != transactionType.Id)
            {
                return BadRequest();
            }

            _transactionTypeService.UpdateTransactionType(transactionType);

            return NoContent();
        }

        // POST: api/TransactionType
        [HttpPost]
        public ActionResult<TransactionType> PostTransactionType(TransactionType transactionType)
        {
            _transactionTypeService.InsertTransactionType(transactionType);

            return CreatedAtAction("GetTransactionType", new { id = transactionType.Id }, transactionType);
        }

        // DELETE: api/TransactionType/5
        [HttpDelete("{id}")]
        public ActionResult<TransactionType> DeleteTransactionType(int id)
        {
            var transactionType = _transactionTypeService.GetTransactionTypeById(id);
            if (transactionType == null)
            {
                return NotFound();
            }

            _transactionTypeService.DeleteTransactionType(id);

            return transactionType;
        }
    }

}

using System.Globalization;
using WebApp.DAL.Models;
using WebApp.DAL.RepositoryInterfaces;
using WebApp.ServiceInterfaces;

namespace WebApp.Service
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;

        public TransactionService(ITransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public IEnumerable<Transaction> GetTransactions()
        {
            return _transactionRepository.GetTransactions();
        }

        public Transaction GetTransactionById(int id)
        {
            return _transactionRepository.GetTransactionById(id);
        }

        public void InsertTransaction(TransactionDto transactionDto)
        {
            var transaction = new Transaction
            {
                Type = transactionDto.Type,
                Amount = transactionDto.Amount,
                Date = DateTime.ParseExact(transactionDto.Date, "dd.MM.yy", CultureInfo.InvariantCulture),
                Description = transactionDto.Description
            };

            _transactionRepository.InsertTransaction(transaction);
            _transactionRepository.Save();
        }

        public void UpdateTransaction(int id, TransactionDto transactionDto)
        {
            var transaction = _transactionRepository.GetTransactionById(id);
            transaction.Type = transactionDto.Type;
            transaction.Amount = transactionDto.Amount;
            transaction.Date = DateTime.ParseExact(transactionDto.Date, "dd.MM.yy", CultureInfo.InvariantCulture);
            transaction.Description = transactionDto.Description;

            _transactionRepository.UpdateTransaction(transaction);
            _transactionRepository.Save();
        }

        public void DeleteTransaction(int id)
        {
            _transactionRepository.DeleteTransaction(id);
            _transactionRepository.Save();
        }
    }

}

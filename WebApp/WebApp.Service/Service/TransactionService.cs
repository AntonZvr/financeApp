using System.Globalization;
using WebApp.DAL.Models;
using WebApp.DAL.RepositoryInterfaces;
using WebApp.Data.DAL.ViewModels;
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

        public void InsertTransaction(TransactionViewModel transactionDto)
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

        public void UpdateTransaction(int id, TransactionViewModel transactionDto)
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

        public DailyReport GetDailyReport(DateTime date)
        {
            var transactionsOnDate = _transactionRepository.GetTransactions()
                                .Where(x => x.Date.Date == date.Date)
                                .ToList();

            var income = transactionsOnDate.Where(x => x.Type.ToLower() == "income")
                                .Sum(x => x.Amount);

            var expenses = transactionsOnDate.Where(x => x.Type.ToLower() == "expense")
                                .Sum(x => x.Amount);

            return new DailyReport
            {
                Income = income,
                Expenses = expenses,
                Transactions = transactionsOnDate
            };
        }

    }

}

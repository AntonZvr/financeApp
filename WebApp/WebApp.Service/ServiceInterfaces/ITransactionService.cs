using WebApp.DAL.Models;
using WebApp.Data.DAL.ViewModels;

namespace WebApp.ServiceInterfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(int id);
        void InsertTransaction(TransactionViewModel transactionDto);
        void UpdateTransaction(int id, TransactionViewModel transactionDto);
        void DeleteTransaction(int id);
    }

}

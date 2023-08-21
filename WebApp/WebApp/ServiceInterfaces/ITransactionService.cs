using WebApp.DAL.Models;

namespace WebApp.ServiceInterfaces
{
    public interface ITransactionService
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(int id);
        void InsertTransaction(TransactionDto transactionDto);
        void UpdateTransaction(int id, TransactionDto transactionDto);
        void DeleteTransaction(int id);
    }

}

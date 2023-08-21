using WebApp.DAL.Models;

namespace WebApp.DAL.RepositoryInterfaces
{
    public interface ITransactionRepository
    {
        IEnumerable<Transaction> GetTransactions();
        Transaction GetTransactionById(int transactionId);
        void InsertTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        void UpdateTransaction(Transaction transaction);
        void Save();
    }

}

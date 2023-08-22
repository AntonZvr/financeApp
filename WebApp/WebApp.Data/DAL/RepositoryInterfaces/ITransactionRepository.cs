using WebApp.DAL.Models;
using WebApp.DAL.Models.WebApp.DAL.Models;

namespace WebApp.DAL.RepositoryInterfaces
{
    public interface ITransactionRepository
    {
        IQueryable<Transaction> GetTransactions();
        Transaction GetTransactionById(int transactionId);
        void InsertTransaction(Transaction transaction);
        void DeleteTransaction(int transactionId);
        void UpdateTransaction(Transaction transaction);
        void Save();
    }

}

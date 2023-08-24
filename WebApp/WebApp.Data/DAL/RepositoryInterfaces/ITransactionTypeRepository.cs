using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.DAL.Models;
using WebApp.Data.DAL.Models;

namespace WebApp.Data.DAL.RepositoryInterfaces
{
    public interface ITransactionTypeRepository
    {
        IEnumerable<TransactionType> GetTransactionTypes();
        TransactionType GetTransactionTypeById(int id);
        void InsertTransactionType(TransactionType transactionType);
        void DeleteTransactionType(int transactionTypeId);
        void UpdateTransactionType(TransactionType transactionType);
        void Save();
        bool TransactionTypeExists(int id);
    }
}

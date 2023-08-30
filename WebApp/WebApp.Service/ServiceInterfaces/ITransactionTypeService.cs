using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.DAL.Models;

namespace WebApp.Service.ServiceInterfaces
{
    public interface ITransactionTypeService
    {
        IEnumerable<TransactionType> GetTransactionTypes();
        TransactionType GetTransactionTypeById(int id);
        void InsertTransactionType(TransactionType transactionType);
        void UpdateTransactionType(TransactionType transactionType);
        void DeleteTransactionType(int id);
        bool TransactionTypeExists(int id);
    }

}

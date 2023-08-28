using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Data.DAL.Models;
using WebApp.Data.DAL.RepositoryInterfaces;
using WebApp.Service.ServiceInterfaces;

namespace WebApp.Service.Service
{
    public class TransactionTypeService : ITransactionTypeService
    {
        private readonly ITransactionTypeRepository _transactionTypeRepository;
        private readonly HttpClient _httpClient;

        public TransactionTypeService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }
        public TransactionTypeService(ITransactionTypeRepository transactionTypeRepository)
        {
            _transactionTypeRepository = transactionTypeRepository;
        }

        public IEnumerable<TransactionType> GetTransactionTypes()
        {
            return _transactionTypeRepository.GetTransactionTypes();
        }

        public TransactionType GetTransactionTypeById(int id)
        {
            return _transactionTypeRepository.GetTransactionTypeById(id);
        }

        public void InsertTransactionType(TransactionType transactionType)
        {
            _transactionTypeRepository.InsertTransactionType(transactionType);
            _transactionTypeRepository.Save();
        }

        public void UpdateTransactionType(TransactionType transactionType)
        {
            _transactionTypeRepository.UpdateTransactionType(transactionType);
            _transactionTypeRepository.Save();
        }

        public void DeleteTransactionType(int id)
        {
            _transactionTypeRepository.DeleteTransactionType(id);
            _transactionTypeRepository.Save();
        }

        public bool TransactionTypeExists(int id)
        {
            return _transactionTypeRepository.TransactionTypeExists(id);
        }
    }

}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Repository;
using WebApp.DAL.Models;
using System.Linq;
using System.Collections.Generic;
using WebApp.DAL.Models.WebApp.DAL.Models;

namespace WebApp
{
    [TestClass]
    public class TransactionRepositoryTests
    {
        private FinanceContext _context;
        private TransactionRepository _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<FinanceContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString()) 
        .Options;

            _context = new FinanceContext(options);
            _repo = new TransactionRepository(_context);
        }

        [TestMethod]
        public void GetTransactions_ShouldReturnAllTransactions()
        {
            // Arrange
            var transaction1 = new Transaction() { TransactionId = 1, Type = 1, Amount = 100.0, Date = DateTime.Now, Description = "Test1" };
            var transaction2 = new Transaction() { TransactionId = 2, Type = 2, Amount = 200.0, Date = DateTime.Now, Description = "Test2" };
            _context.Transactions1.AddRange(transaction1, transaction2);
            _context.SaveChanges();

            // Act
            var result = _repo.GetTransactions();

            // Assert
            Assert.AreEqual(2, result.Count());
            CollectionAssert.Contains(result.ToList(), transaction1);
            CollectionAssert.Contains(result.ToList(), transaction2);
        }

        [TestMethod]
        public void GetTransactionById_ShouldReturnCorrectTransaction()
        {
            // Arrange
            var transaction = new Transaction() { TransactionId = 1, Type = 1, Amount = 100.0, Date = DateTime.Now, Description = "Test" };
            _context.Transactions1.Add(transaction);
            _context.SaveChanges();

            // Act
            var result = _repo.GetTransactionById(1);

            // Assert
            Assert.AreEqual(transaction, result);
        }

        [TestMethod]
        public void InsertTransaction_ShouldAddTransaction()
        {
            // Arrange
            var transaction = new Transaction() { TransactionId = 1, Type = 1, Amount = 100.0, Date = DateTime.Now, Description = "Test" };

            // Act
            _repo.InsertTransaction(transaction);
            _repo.Save();

            // Assert
            Assert.AreEqual(1, _context.Transactions1.Count());
            Assert.AreEqual(transaction, _context.Transactions1.Single());
        }

        [TestMethod]
        public void DeleteTransaction_ShouldRemoveTransaction()
        {
            // Arrange
            var transaction = new Transaction() { TransactionId = 1, Type = 1, Amount = 100.0, Date = DateTime.Now, Description = "Test" };
            _context.Transactions1.Add(transaction);
            _context.SaveChanges();

            // Act
            _repo.DeleteTransaction(1);
            _repo.Save();

            // Assert
            Assert.AreEqual(0, _context.Transactions1.Count());
        }

        [TestMethod]
        public void UpdateTransaction_ShouldUpdateTransaction()
        {
            // Arrange
            var transaction = new Transaction() { TransactionId = 1, Type = 1, Amount = 100.0, Date = DateTime.Now, Description = "Test" };
            _context.Transactions1.Add(transaction);
            _context.SaveChanges();

            // Act
            transaction.Description = "Updated";
            _repo.UpdateTransaction(transaction);
            _repo.Save();

            // Assert
            Assert.AreEqual("Updated", _context.Transactions1.Single().Description);
        }
    }
}
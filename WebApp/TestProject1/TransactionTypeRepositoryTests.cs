using Microsoft.EntityFrameworkCore;
using WebApp.DAL.Models;
using WebApp.Data.DAL.Models;
using WebApp.Data.DAL.Repository;

namespace WebApp
{
    [TestClass]
    public class TransactionTypeRepositoryTests
    {
        private FinanceContext _context;
        private TransactionTypeRepository _repo;

        [TestInitialize]
        public void TestInitialize()
        {
            var options = new DbContextOptionsBuilder<FinanceContext>()
        .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
        .Options;

            _context = new FinanceContext(options);
            _repo = new TransactionTypeRepository(_context);
        }

        [TestMethod]
        public void GetTransactionTypes_ShouldReturnAllTransactionTypes()
        {
            // Arrange
            var transactionType1 = new TransactionType() { Id = 1, Name = "Test1", Category = "Test1" };
            var transactionType2 = new TransactionType() { Id = 2, Name = "Test2", Category = "Test2" };
            _context.TransactionType1.AddRange(transactionType1, transactionType2);
            _context.SaveChanges();

            // Act
            var result = _repo.GetTransactionTypes();

            // Assert
            Assert.AreEqual(2, result.Count());
            CollectionAssert.Contains(result.ToList(), transactionType1);
            CollectionAssert.Contains(result.ToList(), transactionType2);
        }

        [TestMethod]
        public void GetTransactionTypeById_ShouldReturnCorrectTransactionType()
        {
            // Arrange
            var transactionType = new TransactionType() { Id = 1, Name = "Test", Category = "Test" };
            _context.TransactionType1.Add(transactionType);
            _context.SaveChanges();

            // Act
            var result = _repo.GetTransactionTypeById(1);

            // Assert
            Assert.AreEqual(transactionType, result);
        }

        [TestMethod]
        public void InsertTransactionType_ShouldAddTransactionType()
        {
            // Arrange
            var transactionType = new TransactionType() { Id = 1, Name = "Test", Category = "Test" };

            // Act
            _repo.InsertTransactionType(transactionType);
            _repo.Save();

            // Assert
            Assert.AreEqual(1, _context.TransactionType1.Count());
            Assert.AreEqual(transactionType, _context.TransactionType1.Single());
        }

        [TestMethod]
        public void DeleteTransactionType_ShouldRemoveTransactionType()
        {
            // Arrange
            var transactionType = new TransactionType() { Id = 1, Name = "Test", Category = "Test" };
            _context.TransactionType1.Add(transactionType);
            _context.SaveChanges();

            // Act
            _repo.DeleteTransactionType(1);
            _repo.Save();

            // Assert
            Assert.AreEqual(0, _context.TransactionType1.Count());
        }

        [TestMethod]
        public void UpdateTransactionType_ShouldUpdateTransactionType()
        {
            // Arrange
            var transactionType = new TransactionType() { Id = 1, Name = "Test", Category = "Test" };
            _context.TransactionType1.Add(transactionType);
            _context.SaveChanges();

            // Act
            transactionType.Name = "Updated";
            _repo.UpdateTransactionType(transactionType);
            _repo.Save();

            // Assert
            Assert.AreEqual("Updated", _context.TransactionType1.Single().Name);
        }

        [TestMethod]
        public void TransactionTypeExists_ShouldReturnCorrectResult()
        {
            // Arrange
            var transactionType = new TransactionType() { Id = 1, Name = "Test", Category = "Test" };
            _context.TransactionType1.Add(transactionType);
            _context.SaveChanges();

            // Act
            var exists = _repo.TransactionTypeExists(1);

            // Assert
            Assert.IsTrue(exists);
        }
    }
}
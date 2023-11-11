using Moq;
using Ora_08.Logic;
using Ora_08.Model;
using Ora_08.Repository;

namespace ProductLogicTests
{
    [TestFixture]
    public class Tests
    {
        private List<Product> productList;
        private Mock<IRepository<Product>> mockRepository;
        private ProductLogic logic;

        [SetUp]
        public void Setup()
        {
            // Initialize your list of products here
            productList = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Category = "Category A", Price = 100, Stock = 10 },
                new Product { Id = 2, Name = "Product 2", Category = "Category B", Price = 150, Stock = 20 },
                new Product { Id = 3, Name = "Product 3", Category = "Category A", Price = 200, Stock = 0 },
                new Product { Id = 4, Name = "Product 4", Category = "Category C", Price = 80, Stock = 15 },
                new Product { Id = 5, Name = "Product 5", Category = "Category B", Price = 120, Stock = 5 }
            };

            // Mock the repository
            mockRepository = new Mock<IRepository<Product>>();
            mockRepository.Setup(x => x.GetAll()).Returns(productList);

            // Initialize the service with the mocked repository
            logic = new ProductLogic(mockRepository.Object);
        }

        [Test]
        public void GetProductsInCategory_Test()
        {
            var expected = new List<Product>
            {
                new Product { Id = 1, Name = "Product 1", Category = "Category A", Price = 100, Stock = 10 },
                new Product { Id = 3, Name = "Product 3", Category = "Category A", Price = 200, Stock = 0 }
            };

            // Act
            var result = logic.GetProductsInCategory("Category A");

            // Assert
            Assert.That(result, Is.EqualTo(expected));
        }

        [TestCase(100, 3)]
        [TestCase(0, 5)]
        [TestCase(300, 0)]
        [TestCase(200, 0)]
        [TestCase(150, 1)]
        public void GetProductsWithPriceGreaterThan_Test(int num, int expected)
        {
            // Arrange


            // Act
            var result = logic.GetProductsWithPriceGreaterThan(num);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(expected));
        }

        [Test]
        public void GetProductsWithPriceLessThan_Test()
        {
            // Act
            var result = logic.GetProductsWithPriceLessThan(200);

            // Assert
            Assert.That(result.Count(), Is.EqualTo(4));
        }

        [Test]
        public void GetProductsWithMinimumStock_Test()
        {
            // Arrange



            // Act
            var result = logic.GetProductsWithMinimumStock(10);


            // Assert
            Assert.That(result.Count(), Is.EqualTo(3));
        }

        [Test]
        public void IsProductInStock_true_Test()
        {
            // Arrange


            // Act
            bool result = logic.IsProductInStock(2);

            // Assert
            Assert.True(result);
        }

        [Test]
        public void IsProductInStock_false_ProductNull_Test()
        {
            // Arrange


            // Act
            bool result = logic.IsProductInStock(100);

            // Assert
            Assert.False(result);
        }

        [Test]
        public void IsProductInStock_false_StockEmpty_Test()
        {
            // Arrange


            // Act
            bool result = logic.IsProductInStock(3);

            // Assert
            Assert.False(result);
        }
    }
}
using NumberLogic;
using NUnit.Framework;

namespace NumberLogicTests
{
    public class Tests
    {
        Numbers numbers;

        [SetUp]
        public void Setup()
        {
            //Arrange

            numbers = new Numbers();
            for (int i = 0; i < 10; i++)
            {
                numbers.Add(i);
            }
        }

        [Test]
        public void ListNotEmpty_Test()
        {
            //Arrange - Setup metódus

            //Act
            var list = numbers.Get();

            //Assert
            Assert.IsNotEmpty(list);
            //Assert.That(list.Count, Is.EqualTo(10));
        }

        [Test]
        public void ListEmpty_Test()
        {
            //Arrange
            numbers = new Numbers();

            //Act
            var list = numbers.Get();

            //Assert
            Assert.IsEmpty(list);
            //Assert.That(list.Count, Is.EqualTo(10));
        }


        [Test]
        public void AddOk_Test()
        {
            numbers.Add(10);

            var list = numbers.Get();


            Assert.That(list.Contains(10), Is.True);
        }

        [Test]
        public void AddException_Test()
        {
            Exception exception = null;
            try
            {
                numbers.Add(0);
            }
            catch (Exception ex)
            {
                exception = ex;
            }

            Assert.NotNull(exception);

            //Assert.Throws<Exception>(() => numbers.Add(0));
        }


        [TestCase(1, 2, 3)]
        [TestCase(5, 8, 13)]
        [TestCase(100, 423, 523)]
        [TestCase(-5, 2, -3)]
        [TestCase(0, 0, 0)]
        public void Add_Test(int a, int b, int r)
        {
            int result = numbers.Add(a, b);

            Assert.That(result, Is.EqualTo(r));
        }


        [Test]
        public void Sum_Test()
        {
            int result = numbers.Sum();

            Assert.That(result, Is.EqualTo(45));
        }
    }
}
using Numbers;

namespace NumberTests
{
    public class Tests
    {
        NumberLogic logic;

        //Arrange
        [SetUp]
        public void Setup()
        {
            logic = new NumberLogic(5, 10);
        }

        [Test]
        public void IsAEqualsTo5_Test()
        {
            //Arrange - Setup method

            //Act

            //Assert
            Assert.That(logic.A, Is.EqualTo(5));
        }

        [Test]
        public void IsBEqualsTo10_Test()
        {
            //Arrange - Setup method

            //Act

            //Assert
            Assert.That(logic.B, Is.EqualTo(10));
        }

        [Test]
        public void Osszead_Test()
        {
            //Arrange - Setup method

            //Act
            int result = logic.Osszead(2, 5);

            //Assert
            Assert.That(result, Is.EqualTo(7));
        }

        [Test]
        public void Osztas_OK_Test()
        {
            //Arrange - Setup method

            //Act
            int result = logic.Osztas(5, 1);

            //Assert
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Osztas_Exception_Test()
        {
            //Arrange - Setup method

            //Act
            //int result = logic.Osztas(5, 0);

            //Assert
            Assert.Throws<Exception>(() => logic.Osztas(5, 0));
        }

        [TestCase(2, 2, 4)]
        [TestCase(1, 2, 3)]
        [TestCase(2, 0, 2)]
        [TestCase(12, 4, 16)]
        [TestCase(8, 1, 9)]
        public void Osszead_Test2(int a, int b, int result)
        {
            //Arrange - Setup method

            //Act
            int r = logic.Osszead(a, b);

            //Assert
            Assert.That(r, Is.EqualTo(result));
        }

    }
}
using Moq;
using Ora08.Logic;
using Ora08.Model;
using Ora08.Repository;

namespace PersonLogicTest
{
    public class Tests
    {
        List<Person> personList;
        Mock<IRepository<Person>> repositoryMock;
        PersonLogic logic;

        [SetUp]
        public void Setup()
        {
            personList = new List<Person>()
            {
                new Person("test1",12),
                new Person("test2",45),
                new Person("test3",26)
            };

            //Moq
            repositoryMock = new Mock<IRepository<Person>>();
            repositoryMock.Setup(repo => repo.GetAll()).Returns(personList);

            //Init logic
            logic = new PersonLogic(repositoryMock.Object);
        }

        [Test]
        public void AllValuesValid_Test()
        {
            Person result = logic.Get("test1");

            Assert.That(result.Name, Is.EqualTo("test1"));
            Assert.That(result.Age, Is.EqualTo(12));
        }

        [Test]
        public void AllitemsPresent_Test()
        {
            List<Person> list = logic.GetAll().ToList();

            Assert.That(list.Count, Is.EqualTo(3));
        }

        [Test]
        public void Description_Test()
        {

            string result = logic.Description("test1");

            Assert.That(result, Is.EqualTo("test1 - 12"));
        }
    }
}
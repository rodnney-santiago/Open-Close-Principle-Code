using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenClosePrincipleCode;
using System.Linq;

namespace OpenClosePrincipleTestCases
{
    [TestClass]
    public class PersonRepositoryTests
    {
        [TestMethod]
        public void Get_ReturnFourRecords()
        {
            var repository = new PersonRepository();
            var result = repository.Get();

            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void Get_SetValidId_ReturnValidPerson()
        {
            var repository = new PersonRepository();
            var id = 4;
            var person = repository.Get(id);

            Assert.AreEqual(id, person.Id);
        }

        [TestMethod]
        public void Get_InvalidId_ReturnNull()
        {
            var repository = new PersonRepository();
            var id = 7;
            var person = repository.Get(id);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void Add_NewPerson_NewPersonAddedToList()
        {
            var repository = new PersonRepository();
            var person = new Person { FirstName = "Mara", LastName = "Jade" };

            repository.Add(person);

            var newId = 5;
            var newPerson = repository.Get(newId);
            Assert.AreEqual(newId, newPerson.Id);
        }


        [TestMethod]
        public void Delete_NewPersonAddedAndDeleted_NewPersonAddedAndDeletedFromList()
        {
            var repository = new PersonRepository();
            var person = new Person { FirstName = "Mara", LastName = "Jade" };

            repository.Add(person);

            var newId = 5;
            var newPerson = repository.Get(newId);
            Assert.AreEqual(newId, newPerson.Id);

            repository.Delete(newPerson);

            var deletedPerson = repository.Get(newId);

            Assert.IsNull(deletedPerson);
        }

        [TestMethod]
        public void Update_UpdateFirstName_PersonFirtNameDifferentFromOriginal()
        {
            var repository = new PersonRepository();
            var id = 4;
            var person = repository.Get(id);

            Assert.AreEqual(id, person.Id);
            var newName = "Ashoka";
            person.FirstName = newName;
            repository.Update(person);

            person = repository.Get(id);
            Assert.AreEqual(newName, person.FirstName);
        }

    }
}

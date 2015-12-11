using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenClosePrincipleCode;
using System.Linq;

namespace OpenClosePrincipleTestCases
{
    /// <summary>
    /// Summary description for AdaptedRepositoryTests
    /// </summary>
    [TestClass]
    public class AdaptedRepositoryTests
    {
        [TestMethod]
        public void Get_ReturnFourRecords()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);
            var result = adaptedRepository.GetAll();

            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void Get_SetValidId_ReturnValidPerson()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);
            var id = 4;
            var person = adaptedRepository.Get(id);

            Assert.AreEqual(id, person.Id);
        }

        [TestMethod]
        public void Get_InvalidId_ReturnNull()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);
            var id = 7;
            var person = adaptedRepository.Get(id);

            Assert.IsNull(person);
        }

        [TestMethod]
        public void Add_NewPerson_NewPersonAddedToList()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);

            adaptedRepository.Add("Mara", "Jade");

            var newId = 5;
            var newPerson = adaptedRepository.Get(newId);
            Assert.AreEqual(newId, newPerson.Id);
        }


        [TestMethod]
        public void Delete_NewPersonAddedAndDeleted_NewPersonAddedAndDeletedFromList()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);

            adaptedRepository.Add("Mara", "Jade");

            var newId = 5;
            var newPerson = adaptedRepository.Get(newId);
            Assert.AreEqual(newId, newPerson.Id);

            adaptedRepository.Delete(newId);

            var deletedPerson = adaptedRepository.Get(newId);

            Assert.IsNull(deletedPerson);
        }

        [TestMethod]
        public void Update_UpdateFirstName_PersonFirtNameDifferentFromOriginal()
        {
            var repository = new PersonRepository();
            var adaptedRepository = new AdaptedPersonRepository(repository);
            var id = 4;
            var person = adaptedRepository.Get(id);

            Assert.AreEqual(id, person.Id);
            var newName = "Ashoka";
            adaptedRepository.Update(id, newName, person.LastName);

            person = adaptedRepository.Get(id);
            Assert.AreEqual(newName, person.FirstName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public class AdaptedPersonRepository : IAdaptedRepository
    {
        private IPersonRepository _personRepository;

        public AdaptedPersonRepository(IPersonRepository personRepository)
        {
            if (personRepository == null)
            {
                throw new ArgumentNullException("personRepository");
            }

            _personRepository = personRepository;
        }

        public void Add(string firstName, string lastName)
        {
            var person = new Person { FirstName = firstName, LastName = lastName };
            _personRepository.Add(person);
        }

        public void Delete(int id)
        {
            var person = new Person { Id = id };
            _personRepository.Delete(person);
        }

        public Person Get(int id)
        {
            return _personRepository.Get(id);
        }

        public IEnumerable<Person> GetAll()
        {
            return _personRepository.Get();
        }

        public void Update(int id, string firstName, string lastName)
        {
            var person = new Person { Id = id, FirstName = firstName, LastName = lastName };
            _personRepository.Update(person);
        }
    }
}

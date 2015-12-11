using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public class SortedPersonRepository : IPersonRepository
    {
        private IPersonRepository _personRepository;
        private IOrderedEnumerable<Person> _sortedPersons;

        public SortedPersonRepository(IPersonRepository personRepository)
        {
            if(personRepository == null)
            {
                throw new ArgumentNullException("personRepository", "personRepository is null");
            }

            _personRepository = personRepository;
            _sortedPersons = _personRepository.Get().OrderBy(p => p.LastName);
        }

        public void Add(Person person)
        {
            _personRepository.Add(person);
            _sortedPersons = _personRepository.Get().OrderBy(p => p.LastName);
        }

        public void Delete(Person person)
        {
            _personRepository.Delete(person);
            _sortedPersons = _personRepository.Get().OrderBy(p => p.LastName);
        }

        public IEnumerable<Person> Get()
        {
            return _sortedPersons;
        }

        public Person Get(int id)
        {
            return _personRepository.Get(id);
        }

        public void Update(Person person)
        {
            _personRepository.Update(person);
            _sortedPersons = _personRepository.Get().OrderBy(p => p.LastName);
        }
    }
}

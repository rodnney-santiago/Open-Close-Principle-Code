using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public class PersonRepository : IPersonRepository
    {
        private List<Person> persons = new List<Person>
        {
            new Person {Id = 1, FirstName = "Han", LastName = "Solo" },
            new Person {Id = 2, FirstName = "Leia", LastName = "Organa" },
            new Person {Id = 3, FirstName = "Luke", LastName = "Skywalker" },
            new Person {Id = 4, FirstName = "Lando", LastName = "Carlissian" }
        };

        public IEnumerable<Person> Get()
        {
            return persons;
        }

        public void Add(Person person)
        {
            var maxId = persons.Max(p => p.Id);
            person.Id = maxId += 1;
            persons.Add(person);

        }

        public void Delete(Person person)
        {
            var oldPerson = Get(person.Id);
            if (oldPerson != null)
            {
                persons.Remove(oldPerson);
            }
        }

        public void Update(Person person)
        {
            var oldPerson = Get(person.Id);
            if (oldPerson != null)
            {
                oldPerson.FirstName = person.FirstName;
                oldPerson.LastName = person.LastName;
            }
        }

        public Person Get(int id)
        {
            return persons.SingleOrDefault(p => p.Id == id);
        }
    }
}

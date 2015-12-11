using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public interface IPersonRepository
    {
        IEnumerable<Person> Get();
        void Add(Person person);
        void Delete(Person Person);
        void Update(Person person);
        Person Get(int id);
    }
}

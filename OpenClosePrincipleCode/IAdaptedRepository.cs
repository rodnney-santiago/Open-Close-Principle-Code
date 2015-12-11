using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public interface IAdaptedRepository
    {
        IEnumerable<Person> GetAll();
        Person Get(int id);
        void Add(string firstName, string lastName);
        void Delete(int id);
        void Update(int id, string firstName, string lastName);
    }
}

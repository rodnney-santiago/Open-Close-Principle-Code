using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    class Program
    {
        static void Main(string[] args)
        {

            var unsortedRepository = new PersonRepository();
            var unsorted = unsortedRepository.Get();

            Console.WriteLine("Unsorted Records");
            DisplayNames(unsorted);

            var sortedRepository = new SortedPersonRepository(unsortedRepository);
            var sorted = sortedRepository.Get();

            Console.WriteLine("Sorted Records");
            DisplayNames(sorted);

            Console.Read();
        }

        static void DisplayNames(IEnumerable<Person> list)
        {
            foreach (var person in list)
            {
                var message = string.Format("Id: {0}, Full Name: {1}", person.Id, person.FullName());
                Console.WriteLine(message);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenClosePrincipleCode
{
    public static class ExtensionMethods
    {
        public static string FullName(this Person person)
        {
            return person.FirstName + ' ' + person.LastName;
        }
    }
}

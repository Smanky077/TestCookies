using CookesMafia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Servises
{
    public interface ICookieService
    {
        public bool BuyCookie(Person perses);
        public List<Person> BuyCookie(List<Person> perses);

        public void ReturnDebit(Person perses);
        public List<Person>  ReturnDebit(int Id);
    }
}

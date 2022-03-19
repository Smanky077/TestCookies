using CookesMafia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Repositories
{
    public interface IRepository
    {
        public List<Person> Get();
        public Person GetById(int Id);
        public Person Post(Person person);
        public Debit PostDebit(Debit d);
        public Person Put(Person person);
        public bool Put(List<Person> persons);
    }
}

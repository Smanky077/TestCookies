using CookesMafia.Context;
using CookesMafia.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Repositories
{
    public class Repository : IRepository
    {
        private EntityContext context;


        public Repository(EntityContext con)
        {
            context = con;
            
        }

        public List<Person> Get()
        {

            var Perses = context.Persones
                .Include(d=>d.Debites)
                .Include(d=>d.Borrowes)
                .AsNoTracking()
                .ToList();

            return Perses;
        }

        public Person GetById(int Id)
        {
            var pers = context.Persones
                .Where(d=>d.Id==Id)
                .Include(p=>p.Debites)
                .Include(b=>b.Borrowes).AsNoTracking().ToList()[0];
            if (pers != null)
            {
                return pers;
            }
            return null;
        }

        public Person Post(Person person)
        {
                if (person != null)
                {
                    context.Persones.Add(person);
                    context.SaveChanges();
                    return person;
                }
                return null;
        }

        public Debit PostDebit(Debit d)
        {
            if (d != null)
            {
                context.Debites.Add(d);
                context.SaveChanges();
                return d;
            }
            return null;
        }
        public Person Put(Person person)
        {
            if(person != null)
            {
                context.Entry(person).State = EntityState.Modified;
                //context.Entry(person.Debites).State = EntityState.Modified;
                context.SaveChanges();
                return person;
            }
            return null;
        }
        public bool Put(List<Person> persons)
        {
            if (persons != null)
            {
                //context.Entry(persons).State = EntityState.Modified;
                //context.Entry(person.Debites).State = EntityState.Modified;
                foreach(var p in persons)
                {
                    p.Borrowes = null;
                }
                context.UpdateRange(persons);
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

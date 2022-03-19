using CookesMafia.Context;
using CookesMafia.Models;
using CookesMafia.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Servises
{
    public class CookiesService : ICookieService
    {
        IRepository repo;
        EntityContext context;
        public CookiesService(IRepository r, EntityContext c)
        {
            repo = r;
            context = c;
        }
        public List<Person> BuyCookie(List<Person> perses)
        {
            if (!repo.Put(perses)) return null;
            return perses;
        }


        public bool BuyCookie(Person perses)
        {
            throw new NotImplementedException();
        }

        public void ReturnDebit(Person perses)
        {
            throw new NotImplementedException();
        }

        public List<Person> ReturnDebit(int id)
        {
            Person curr = repo.GetById(id);
            if (curr.Debites.Count == 0) return null;

            List<Debit> debs = curr.Debites;
            List<Person> borrowes = new List<Person>();

            try
            {
                borrowes = context.Persones
                .Where(p => p.Borrowes.Any(a => a.PersonId == id))
                .AsNoTracking().ToList();
            }
            catch (Exception e)
            {

                return null;
            }
            
            if (borrowes.Count == 0) return null;

            foreach (var b in borrowes)
            {
                var currBorrDeb = debs.Where(d => d.BorrowerId == b.Id).ToList();

                if (currBorrDeb.Count == 0) continue;

                foreach (var d in currBorrDeb)
                {
                    b.Money += d.DebSum;
                    curr.Money -= d.DebSum;
                    curr.Alldebit -= d.DebSum;
                }
            }
            context.Update(curr);
            context.UpdateRange(borrowes);
            context.RemoveRange(debs);
            try
            {
                context.SaveChanges();
                return repo.Get();
            }
            catch (Exception e)
            {
                return null;
            }

        }

       
    }
}

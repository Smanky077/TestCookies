using CookesMafia.Models;
using CookesMafia.Repositories;
using CookesMafia.Servises;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Controllers
{
    [ApiController]
    public class CookieController : ControllerBase
    {
        private IRepository repository;
        private ICookieService servise;
        public CookieController(IRepository repo, ICookieService s)
        {
            repository = repo;
            servise = s;
        }


        [HttpGet]
        [Route("[action]")]
        [Route("Cookie/GetAll")]
        public List<Person> GetAll()
        {
            return repository.Get();
        }
        [HttpPost]
        [Route("[action]")]
        [Route("Cookie/AddPerson")]
        public Person Add(Person pers)
        {
            return repository.Post(pers);
        }

        [HttpPut]
        [Route("[action]")]
        [Route("Cookie/UpdatePerson")]
        public Person UpdatePerson(Person pers)
        {
            return repository.Put(pers);
        }
        
        [HttpPut]
        [Route("[action]")]
        [Route("Cookie/UpdatePersones")]
        public List<Person> UpdatePersons(IEnumerable<Person> perses)
        {
            List<Person> persones;
            try
            {
                persones = servise.BuyCookie(perses.ToList());
            }
            catch (Exception e)
            {
                return null;
            }
            return persones;
        }
        [HttpPost]
        [Route("[action]")]
        [Route("Cookie/ReturnDebs")]
        public List<Person> ReturnDebs(IdClass idc)
        {
            return servise.ReturnDebit(idc.Id);
        }
    }
}

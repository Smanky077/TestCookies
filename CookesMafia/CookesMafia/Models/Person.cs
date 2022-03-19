using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CookesMafia.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; } 
        public double Money { get; set; }
        public double Alldebit { get; set; }
        [InverseProperty("Person")]
        public  List<Debit> Debites { get; set; }
        [InverseProperty("Borrower")]
        public  List<Debit> Borrowes { get; set; }

        public Person()
        {
            Debites = new List<Debit>();
            Borrowes = new List<Debit>();
        }
    }
}

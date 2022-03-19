using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CookesMafia.Models
{
    public class Debit
    {
       public int Id { get; set; }
       public int PersonId { get; set; }
       public int BorrowerId { get; set; }
       public double DebSum { get; set; }
       //public bool Complite { get; set; }
       [JsonIgnore]
       public  Person Person { get; set; }
       [JsonIgnore]
       public  Person Borrower { get; set; }
    }
}

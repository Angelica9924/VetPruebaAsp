using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
//Para la anotación Key y aclarar que es la llave primaria
using System.ComponentModel.DataAnnotations;


namespace Vet.Models
{
    public class Quote
    {
        [Key]
        public int QuoteId { get; set; }
        public required DateTime Date { get; set; }
        public int PetId { get; set; }
        public Pet Pet { get; set; }
        public int VetId { get; set; }
        public Vete Vet { get; set; }
        public required string Description { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para activar el JsonIgnore
using System.Text.Json.Serialization;
//Para la anotación Key y aclarar que es la llave primaria
using System.ComponentModel.DataAnnotations;

namespace Vet.Models
{
    public class Pet
    {
        [Key]
        public int PetId { get; set; }
        public required string Name { get; set; }
        public required string Specie { get; set; }
        public required string Race { get; set; }
        public required DateTime DateBirth { get; set; }
        public int OwnerId { get; set; }
        public Owner Owner { get; set; }
        public required string Photo { get; set; }
        [JsonIgnore]
        public List<Quote> Quotes { get; set; }
        
    }
}
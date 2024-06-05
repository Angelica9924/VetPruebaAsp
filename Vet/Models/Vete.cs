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
    public class Vete
    {
        [Key]
        public int VetId { get; set; }
        public required string Name { get; set; }
        public required string Phone { get; set; }
        public required string Address { get; set; }
        public required string Email { get; set; }
        [JsonIgnore]
        public List<Quote> Quotes { get; set; }
    }
}
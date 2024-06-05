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
    public class Owner
    {
        [Key]
        public int OwnerId { get; set; }
        public required string Names { get; set; }
        public required string LastNames { get; set; }
        public required string Email { get; set; }
        public required string Address { get; set; }
        public required string Phone { get; set; }
        [JsonIgnore]
        public List<Pet> Pets { get; set; }
    }
}
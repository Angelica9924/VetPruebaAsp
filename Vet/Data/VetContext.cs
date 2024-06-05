using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para activar el uso de los modelos
using Vet.Models;
//Para poder conectar la base de datos
using Microsoft.EntityFrameworkCore;

namespace Vet.Data
{
    public class VetContext : DbContext
    {
        //Contruimos la conexión
        public VetContext (DbContextOptions<VetContext> options): base(options)
        {}

        //Registramos los modelos (Tuve que cambiar el nombre del modelo Vet por Vete porque llame el proyecto Vet y no podía tener el nombre del namespace)
        public DbSet<Vete> Vets { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<Quote> Quotes { get; set; }

    }
}
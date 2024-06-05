using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;
//Para usar la conexión con la db
using Vet.Data;
using Microsoft.EntityFrameworkCore;

namespace Vet.Services
{
    public class VetRepository : IVetRepository
    {
        private readonly VetContext _context;

        public VetRepository(VetContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Vete>> GetAllAsync()
        {
            return await _context.Vets.ToListAsync();
        }

        public async Task<Vete> GetByIdAsync(int id)
        {
            return await _context.Vets.FindAsync(id);
        }
    }
}
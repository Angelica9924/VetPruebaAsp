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
    public class OwnerRepository : IOwnerRepository
    {
        private readonly VetContext _context;

        public OwnerRepository(VetContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Owner owner)
        {
            await _context.Owners.AddAsync(owner);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Owner>> GetAllAsync()
        {
            return await _context.Owners.ToListAsync();
        }

        public async Task<Owner> GetByIdAsync(int id)
        {
            return await _context.Owners.FindAsync(id);
        }

        public async Task UpdateAsync(Owner owner)
        {
            _context.Owners.Update(owner);
            await _context.SaveChangesAsync();
        }
    }
}
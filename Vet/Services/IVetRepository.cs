using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;

namespace Vet.Services
{
    public interface IVetRepository
    {
        Task<IEnumerable<Vete>> GetAllAsync();
        Task<Vete> GetByIdAsync(int id);
    }
}
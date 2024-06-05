using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;
//Y para usar la información que requiera de varios modelos
using Vet.DTO;

namespace Vet.Services
{
    public interface IPetRepository
    {
        Task<IEnumerable<Pet>> GetAllAsync();
        Task<Pet> GetByIdAsync(int id);
        Task AddAsync(Pet pet);
        Task UpdateAsync(Pet pet);
        Task<List<OwnerPet>> GetByOwnerId(int ownerId);
        Task<List<BirthdayOwner>> GetByBirthday(string date);
    }
}
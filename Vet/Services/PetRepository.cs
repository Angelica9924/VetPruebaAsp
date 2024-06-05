using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;
//Para usar la conexión con la db
using Vet.Data;
using Microsoft.EntityFrameworkCore;
using Vet.DTO;

namespace Vet.Services
{
    public class PetRepository : IPetRepository
    {
        private readonly VetContext _context;

        public PetRepository(VetContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Pet pet)
        {
            await _context.Pets.AddAsync(pet);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Pet>> GetAllAsync()
        {
            return await _context.Pets.Include(b => b.Owner).ToListAsync();
        }

        public async Task<List<BirthdayOwner>> GetByBirthday(string date)
        {
            List<BirthdayOwner> birthday = new List<BirthdayOwner>();

            // Consulta para obtener citas que coincidan con el médico y la fecha
            var pets = await _context.Pets
                .Where(c => c.DateBirth.ToString().Contains(date)).Include(c => c.Owner).ToListAsync();
            foreach (var pet in pets)
            {
                BirthdayOwner owner = new BirthdayOwner
                {
                    NamePet = pet.Name,
                    NameOwner = pet.Owner.Names,
                    EmailOwner = pet.Owner.Email,
                    PhoneOwner = pet.Owner.Phone
                };
                birthday.Add(owner);
            }

            return birthday;
        }
        

        public async Task<Pet> GetByIdAsync(int id)
        {
            return await _context.Pets.Include(b => b.Owner).FirstOrDefaultAsync(b => b.PetId == id);
        }


        public async Task<List<OwnerPet>> GetByOwnerId(int ownerId)
        {
            List<OwnerPet> pet = new List<OwnerPet>();

            var count = _context.Pets.ToList().Where(c => c.OwnerId == ownerId).Count();
            var Pet = await _context.Pets.Where(c => c.OwnerId == ownerId).Include(m => m.Owner).ToListAsync();

            for (int i = 0; i < count; i++){
                OwnerPet owner = new OwnerPet();
                owner.NameOwner = Pet[i].Owner.Names;
                owner.EmailOwner = Pet[i].Owner.Email;
                owner.NamePet = Pet[i].Name;
                owner.SpeciePet = Pet[i].Specie;
                owner.RacePet = Pet[i].Race;
                pet.Add(owner);
            }

            return pet;
        }
        

        public async Task UpdateAsync(Pet pet)
        {
            _context.Pets.Update(pet);
            await _context.SaveChangesAsync(); 
        }
    }
}
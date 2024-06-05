using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos en los controladores
using Vet.Models;
using Microsoft.AspNetCore.Mvc;
//Para hacer funcionales los servicios
using Vet.Services;

namespace Vet.Controllers.Pets
{
    public class PetsController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetsController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
    
        [HttpGet]
        [Route("api/pets")]
        public async Task<ActionResult<IEnumerable<Pet>>> GetPets()
        {
            return Ok(await _petRepository.GetAllAsync());
        }
        
        [HttpGet]
        [Route("api/pets/{id}")]
        public async Task<ActionResult<Pet>> GetPet(int id)
        {
            var pet = await _petRepository.GetByIdAsync(id);
            if (pet == null)
            {
                return NotFound();
            }
            return Ok(pet);
        }

         [HttpGet]
        [Route("api/pets/{ownerId}/owner")]
        public async Task<IActionResult> GetByOwnerId(int ownerId)
        {
            var pets = await _petRepository.GetByOwnerId(ownerId);
            if (pets == null || !pets.Any())
            {
                return StatusCode(200, "You have no pets to your name");
            }
            return Ok(pets);
        }

        [HttpGet]
        [Route("api/pets/{date}/birthday")]
        public async Task<IActionResult>GetByBirthday(string date)
        {
            var owners = await _petRepository.GetByBirthday(date);
            if (owners == null || !owners.Any())
            {
                return StatusCode(200, "You have no pets to your name");
            }
            return Ok(owners);
        }
    }
}
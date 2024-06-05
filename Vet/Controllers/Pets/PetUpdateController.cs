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
    public class PetUpdateController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetUpdateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }

        [HttpPut]
        [Route("api/pets/{id}")]
        public async Task<IActionResult> PutPet(int id, Pet pet)
        {
            if (id != pet.PetId)
            {
                return BadRequest();
            }
            try{
            await _petRepository.UpdateAsync(pet);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Please enter the species field (Dog, Cat Bird) and the breed field (Husky, Pitbull or Yorkie)");
            }
        }
        
    }
}
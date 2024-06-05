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
    public class PetCreateController: ControllerBase
    {
        private readonly IPetRepository _petRepository;

        public PetCreateController(IPetRepository petRepository)
        {
            _petRepository = petRepository;
        }
        
        [HttpPost]
        [Route("api/pets")]
        public async Task<ActionResult<Pet>> PostPet(Pet pet)
        {
            try
            {
                // Lógica para agregar la mascota a la base de datos
                await _petRepository.AddAsync(pet);
                return Ok(new { message = "New pet" });
            }
            catch (Exception)
            {
                return StatusCode(500, "Please enter the species field (Dog, Cat Bird) and the breed field (Husky, Pitbull or Yorkie)");
            }
        } 
        
    }
}
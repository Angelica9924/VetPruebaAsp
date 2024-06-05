using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos en los controladores
using Vet.Models;
using Microsoft.AspNetCore.Mvc;
//Para hacer funcionales los servicios
using Vet.Services;


namespace Vet.Controllers.Owners
{
    public class OwnerCreateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerCreateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        [HttpPost]
        [Route("api/owners")]
        public async Task<ActionResult<Owner>> PostOwner(Owner owner)
        {
            try
            {
                // Lógica para agregar el dueño a la base de datos
                await _ownerRepository.AddAsync(owner);
                return Ok(new { message = "New owner" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating owner: {ex.Message}");
            }
        } 
    }
}
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
    public class OwnerUpdateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnerUpdateController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        [HttpPut]
        [Route("api/owners/{id}")]
        public async Task<IActionResult> PutOwner(int id, Owner owner)
        {
            if (id != owner.OwnerId)
            {
                return BadRequest();
            }
            try{
            await _ownerRepository.UpdateAsync(owner);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Fail");
            }
        }
    }
}
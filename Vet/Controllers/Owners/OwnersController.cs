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
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerRepository _ownerRepository;

        public OwnersController(IOwnerRepository ownerRepository)
        {
            _ownerRepository = ownerRepository;
        }
        
        [HttpGet]
        [Route("api/owners")]
        public async Task<ActionResult<IEnumerable<Owner>>> GetOwners()
        {
            return Ok(await _ownerRepository.GetAllAsync());
        }
        
        [HttpGet]
        [Route("api/owners/{id}")]
        public async Task<ActionResult<Owner>> GetOwner(int id)
        {
            var owner = await _ownerRepository.GetByIdAsync(id);
            if (owner == null)
            {
                return NotFound();
            }
            return Ok(owner);
        }
    }
}
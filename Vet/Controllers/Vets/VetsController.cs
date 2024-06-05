using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos en los controladores
using Vet.Models;
using Microsoft.AspNetCore.Mvc;
//Para hacer funcionales los servicios
using Vet.Services;

namespace Vet.Controllers.Vets
{
    public class VetsController : ControllerBase
    {
        private readonly IVetRepository _vetRepository;

        public VetsController(IVetRepository vetRepository)
        {
            _vetRepository = vetRepository;
        }
        
        [HttpGet]
        [Route("api/vets")]
        public async Task<ActionResult<IEnumerable<Vete>>> GetVets()
        {
            return Ok(await _vetRepository.GetAllAsync());
        }
        
        [HttpGet]
        [Route("api/vets/{id}")]
        public async Task<ActionResult<Vete>> GetVet(int id)
        {
            var vet = await _vetRepository.GetByIdAsync(id);
            if (vet == null)
            {
                return NotFound();
            }
            return Ok(vet);
        }
    }
    
}
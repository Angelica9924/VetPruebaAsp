using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos en los controladores
using Vet.Models;
using Microsoft.AspNetCore.Mvc;
//Para hacer funcionales los servicios
using Vet.Services;

namespace Vet.Controllers.Quotes
{
    public class QuoteUpdateController: ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteUpdateController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
    
        [HttpPut]
        [Route("api/quotes/{id}")]
        public async Task<IActionResult> PutQuote(int id, Quote quote)
        {
            if (id != quote.QuoteId)
            {
                return BadRequest();
            }
            try{
            await _quoteRepository.UpdateAsync(quote);
            return NoContent();
            }
            catch (Exception)
            {
                return StatusCode(500,"Fail");
            }
        }
    }
}
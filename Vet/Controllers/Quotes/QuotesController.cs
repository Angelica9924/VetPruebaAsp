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
    public class QuotesController: ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuotesController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
        
        [HttpGet]
        [Route("api/quotes")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetQuotes()
        {
            return Ok(await _quoteRepository.GetAllAsync());
        }
        
        [HttpGet]
        [Route("api/quotes/{id}")]
        public async Task<ActionResult<Quote>> GetQuote(int id)
        {
            var quote = await _quoteRepository.GetByIdAsync(id);
            if (quote == null)
            {
                return NotFound();
            }
            return Ok(quote);
        }

        [HttpGet]
        [Route("api/quotes/{date}/date")]
        public async Task<ActionResult<IEnumerable<Quote>>> GetByDate( string date)
        {
            var quotes = await _quoteRepository.GetByDate(date);
            return Ok(quotes);
        }

        [HttpGet]
        [Route("api/quotes/{vetId}/vets")]
        public async Task<IActionResult> GetByVetId(int vetId)
        {
            var quotes = await _quoteRepository.GetByVetId(vetId);
            if (quotes == null || !quotes.Any())
            {
                return StatusCode(200, "You have no appointments to your name");
            }
            return Ok(quotes);
        }
    }
}

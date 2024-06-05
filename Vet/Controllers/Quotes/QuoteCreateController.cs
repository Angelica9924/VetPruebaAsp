using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos en los controladores
using Vet.Models;
using Microsoft.AspNetCore.Mvc;
//Para hacer funcionales los servicios
using Vet.Services;
//Para poder usar el codigo del correo
using Vet.Controllers.Mail;

namespace Vet.Controllers.Quotes
{
    public class QuoteCreateController: ControllerBase
    {
        private readonly IQuoteRepository _quoteRepository;

        public QuoteCreateController(IQuoteRepository quoteRepository)
        {
            _quoteRepository = quoteRepository;
        }
    
        [HttpPost]
        [Route("api/quotes")]
        public async Task<ActionResult<Quote>> PostQuote(Quote quote)
        {
            try
            {
                // Lógica para agregar la cita a la base de datos
                await _quoteRepository.AddAsync(quote);

                // Lógica para enviar el correo
                MailController Email = new MailController();
                Email.SendEmailAsync(); 
                return Ok(new { message = "New quote and email sended" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating quote: {ex.Message}");
            }
        } 
        
    }
}
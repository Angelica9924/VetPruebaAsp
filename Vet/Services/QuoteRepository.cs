using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;
//Para usar la conexión con la db
using Vet.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Vet.DTO;

namespace Vet.Services
{
    public class QuoteRepository : IQuoteRepository
    {
        private readonly VetContext _context;

        public QuoteRepository(VetContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Quote quote)
        {
            await _context.Quotes.AddAsync(quote);
            await _context.SaveChangesAsync(); 
        }

        public async Task<IEnumerable<Quote>> GetAllAsync()
        {
            return await _context.Quotes.Include(b => b.Pet).ThenInclude(m => m.Owner).Include(b => b.Vet).ToListAsync();
        }

        public async Task<IEnumerable<Quote>> GetByDate(string date)
        {
            return await _context.Quotes.Where(c =>c.Date.ToString().Contains(date)).Include(b => b.Pet).ThenInclude(m => m.Owner).Include(b => b.Vet).ToListAsync();
        }

        public async Task<Quote> GetByIdAsync(int id)
        {
            return await _context.Quotes.Include(b => b.Pet).ThenInclude(m => m.Owner).Include(b => b.Vet).FirstOrDefaultAsync(b => b.QuoteId == id);
        }

        public async Task<List<QuoteVet>> GetByVetId(int vetId)
        {
            List<QuoteVet> vet = new List<QuoteVet>();

            var count = _context.Quotes.ToList().Where(c => c.VetId == vetId).Count();
            var Quote = await _context.Quotes.Where(c => c.VetId == vetId).Include(b => b.Pet).ThenInclude(m => m.Owner).Include(b => b.Vet).ToListAsync();

            for (int i = 0; i < count; i++){
                QuoteVet quotes = new QuoteVet();
                quotes.NameVet = Quote[i].Vet.Name;
                quotes.EmailVet = Quote[i].Vet.Email;
                quotes.DateQuote = Quote[i].Date;
                quotes.DescriptionQuote = Quote[i].Description;
                vet.Add(quotes);
            }

            return vet;
        }

        public async Task UpdateAsync(Quote quote)
        {
            _context.Quotes.Update(quote);
            await _context.SaveChangesAsync();
        }
    }
}
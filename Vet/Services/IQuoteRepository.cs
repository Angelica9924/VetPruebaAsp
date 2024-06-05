using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Para usar los modelos
using Vet.Models;
//Y para usar la información que requiera de varios modelos
using Vet.DTO;

namespace Vet.Services
{
    public interface IQuoteRepository
    {
        Task<IEnumerable<Quote>> GetAllAsync();
        Task<Quote> GetByIdAsync(int id);
        Task AddAsync(Quote quote);
        Task UpdateAsync(Quote quote);
        Task<IEnumerable<Quote>> GetByDate(string date);
        Task<List<QuoteVet>> GetByVetId(int vetId);
    }
}
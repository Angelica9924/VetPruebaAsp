using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Vet.DTO
{
    public class QuoteVet
    {
        public string NameVet { get; set; }
        public string EmailVet { get; set; }
        public DateTime DateQuote { get; set; }
        public string DescriptionQuote { get; set; }
    }
}
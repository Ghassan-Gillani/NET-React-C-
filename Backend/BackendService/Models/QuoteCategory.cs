using System.Collections.Generic;

namespace BackendService.Models
{
    public class QuoteCategory
    {
        public string CategoryName { get; set; }
        public List<Quote> Quotes { get; set; }
    }
}

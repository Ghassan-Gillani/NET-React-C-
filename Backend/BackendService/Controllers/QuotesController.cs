using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BackendService.Models;
using BackendService.Services;

namespace BackendService.Controllers
{
    [ApiController]
    [Route("api/quotes")]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteService _quoteService;

        public QuotesController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet("random")]
        public async Task<ActionResult<Quote>> GetRandomQuote()
        {
            var quote = await _quoteService.GetRandomQuote();
            if (quote == null)
                return NotFound();

            return quote;
        }

        [HttpGet("author/{authorName}")]
        public async Task<ActionResult<IEnumerable<QuoteCategory>>> GetQuotesByAuthor(string authorName)
        {
            var quotesByAuthor = await _quoteService.GetQuotesByAuthor(authorName);
            if (quotesByAuthor == null)
                return NotFound();

            return quotesByAuthor;
        }
    }
}

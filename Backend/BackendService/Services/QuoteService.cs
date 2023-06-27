using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BackendService.Models;

namespace BackendService.Services
{
    public class QuoteService
    {
        private List<Quote> _quotes;

        public QuoteService()
        {
            // Initialize the list of quotes
            _quotes = new List<Quote>
            {
                new Quote { Content = "Quote 1", Author = "Author 1" },
                new Quote { Content = "Quote 2", Author = "Author 2" },
                new Quote { Content = "Quote 3", Author = "Author 3" }
            };
        }

        public async Task<Quote> GetRandomQuote()
        {
            // Generate a random index within the range of the quotes list
            Random random = new Random();
            int index = random.Next(_quotes.Count);

            // Retrieve and return the quote at the random index
            return await Task.FromResult(_quotes[index]);
        }

        public async Task<List<QuoteCategory>> GetQuotesByAuthor(string authorName)
        {
            List<QuoteCategory> quotesByAuthor = new List<QuoteCategory>();

            // Iterate through each quote and check if the author matches
            foreach (var quote in _quotes)
            {
                if (quote.Author.Equals(authorName, StringComparison.OrdinalIgnoreCase))
                {
                    // Check if a category with the author name already exists
                    var category = quotesByAuthor.Find(c => c.CategoryName.Equals(authorName, StringComparison.OrdinalIgnoreCase));
                    if (category != null)
                    {
                        // Add the quote to the existing category
                        category.Quotes.Add(quote);
                    }
                    else
                    {
                        // Create a new category and add the quote
                        quotesByAuthor.Add(new QuoteCategory
                        {
                            CategoryName = authorName,
                            Quotes = new List<Quote> { quote }
                        });
                    }
                }
            }

            // Return the list of quote categories
            return await Task.FromResult(quotesByAuthor);
        }
    }
}

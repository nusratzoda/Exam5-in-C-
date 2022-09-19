namespace WebApi;

using Microsoft.AspNetCore.Mvc;
using Services;
using Domain;
public class QuoteController
{
    private QouteServices _quoteservices;
    public QuoteController()
    {
        _quoteservices = new QouteServices();
    }
    [HttpGet]
    public async Task<List<Quote>> GetQuotes()
    {
        return await _quoteservices.GetAuthors();
    }
    [HttpPost]
    public async Task<int> AddQueryText(Quote quote)
    {
        return await _quoteservices.AddQuote(quote);
    }

    [HttpPut]
    public async Task<int> UpdateQueryText(Quote quote)
    {
        return await _quoteservices.UpdateQuote(quote);
    }
    [HttpDelete]
    public async Task<int> GetQueryText(int id)
    {
        return await _quoteservices.DeleteQuote(id);
    }
}

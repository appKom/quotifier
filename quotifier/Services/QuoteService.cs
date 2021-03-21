using Quotifier.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;

namespace Quotifier.Services
{
    public class QuoteService
    {
        private readonly IMongoCollection<Quote> _quotes;

        public QuoteService(IQuotifierDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _quotes = database.GetCollection<Quote>(settings.QuotesCollectionName);
        }

        public List<Quote> Get() =>
            _quotes.Find(quote => true).ToList();

        public Quote Get(string id) =>
            _quotes.Find<Quote>(quote => quote.Id == id).FirstOrDefault();

        public Quote Create(Quote quote)
        {
            _quotes.InsertOne(quote);
            return quote;
        }

        public void Update(string id, Quote quoteIn) =>
            _quotes.ReplaceOne(quote => quote.Id == id, quoteIn);

        public void Remove(string id) =>
            _quotes.DeleteOne(quote => quote.Id == id);

        public void Remove(Quote quoteIn) =>
            _quotes.DeleteOne(quote => quote.Id == quoteIn.Id);
    }
}


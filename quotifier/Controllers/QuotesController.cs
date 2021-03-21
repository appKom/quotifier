using Quotifier.Models;
using Quotifier.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Quotifier.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteService _quoteService;

        public QuotesController(QuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        [HttpGet]
        public ActionResult<List<Quote>> Get() =>
            _quoteService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Quote> Get(string id)
        {
            var quote = _quoteService.Get(id);

            if (quote == null)
            {
                return NotFound();
            }

            return quote;
        }

        [HttpPost]
        public ActionResult<Quote> Create(Quote quote)
        {
            _quoteService.Create(quote);

            return CreatedAtRoute("GetBook", new { id = quote.Id.ToString() }, quote);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Quote quoteIn)
        {
            var quote = _quoteService.Get(id);

            if(quote == null)
            {
                return NotFound();
            }

            _quoteService.Update(id, quoteIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Remove(string id)
        {
            var quote = _quoteService.Get(id);

            if(quote == null)
            {
                return NotFound();
            }

            _quoteService.Remove(quote.Id);

            return NoContent();
        }
    }
}
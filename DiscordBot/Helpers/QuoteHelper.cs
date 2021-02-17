using DiscordBot.Helpers.Interfaces;
using System;
using System.Threading.Tasks;

namespace DiscordBot.Helpers
{
    public class QuoteHelper : IQuoteHelper
    {
        public async Task<string> GenerateQuote(string quote, string author)
        {
            await Task.Delay(200);
            return $"_‟{quote}“_ – {author}, {DateTime.UtcNow:yyyy}";
        }
    }
}

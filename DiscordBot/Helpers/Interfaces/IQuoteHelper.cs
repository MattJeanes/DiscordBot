using System.Threading.Tasks;

namespace DiscordBot.Helpers.Interfaces
{
    public interface IQuoteHelper
    {
        Task<string> GenerateQuote(string quote, string author);
    }
}

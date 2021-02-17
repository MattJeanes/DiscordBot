using DiscordBot.Helpers.Interfaces;
using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Discord
{
    public class QuoteCommand : BaseCommand
    {
        private readonly IQuoteHelper _quoteHelper;

        public override string Command => "quote";

        public QuoteCommand(IServiceProvider serviceProvider, IQuoteHelper quoteHelper) : base(serviceProvider)
        {
            _quoteHelper = quoteHelper;
        }

        public override async Task ProcessMessage(MessageCreateEventArgs e, List<string> args)
        {
            if (args.Count != 2)
            {
                await e.Message.RespondAsync($"Syntax: `\"<quote>\" \"<author>\"`");
                return;
            }
            var quote = args[0];
            var author = args[1];
            var generatedQuote = await _quoteHelper.GenerateQuote(quote, author);
            await e.Message.RespondAsync(generatedQuote);
        }
    }
}

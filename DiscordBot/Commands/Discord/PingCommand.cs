using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Discord
{
    public class PingCommand : BaseCommand
    {
        public override string Command => "ping";

        public PingCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override Task ProcessMessage(MessageCreateEventArgs e, List<string> args)
        {
            return e.Message.RespondAsync("Pong!");
        }
    }
}

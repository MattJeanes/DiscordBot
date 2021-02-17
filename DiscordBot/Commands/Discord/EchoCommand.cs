using DSharpPlus.EventArgs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Discord
{
    public class EchoCommand : BaseCommand
    {
        public override string Command => "echo";

        public EchoCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }

        public override Task ProcessMessage(MessageCreateEventArgs e, List<string> args)
        {
            return e.Message.RespondAsync($"You said: {string.Join(",", args)}");
        }
    }
}

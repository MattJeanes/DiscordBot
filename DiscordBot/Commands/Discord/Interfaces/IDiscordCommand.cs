using DSharpPlus.EventArgs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Discord.Interfaces
{
    public interface IDiscordCommand
    {
        string Command { get; }
        //string Permission { get; }
        Task ProcessMessage(MessageCreateEventArgs e, List<string> args);
        Task MemberRemoved(GuildMemberRemoveEventArgs e);
    }
}

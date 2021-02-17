using DiscordBot.Commands.Discord.Interfaces;
using DiscordBot.Data.Options;
using DSharpPlus.EventArgs;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DiscordBot.Commands.Discord
{
    public class BaseCommand : IDiscordCommand
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly DiscordOptions _baseOptions;

        public virtual string Command => null;

        public BaseCommand(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _baseOptions = _serviceProvider.GetRequiredService<IOptions<DiscordOptions>>().Value;
        }

        public virtual Task ProcessMessage(MessageCreateEventArgs e, List<string> args)
        {
            return Task.CompletedTask;
        }

        public virtual Task MemberRemoved(GuildMemberRemoveEventArgs e)
        {
            return Task.CompletedTask;
        }
    }
}
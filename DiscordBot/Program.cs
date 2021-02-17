using DiscordBot.Commands.Discord;
using DiscordBot.Commands.Discord.Interfaces;
using DiscordBot.Data.Options;
using DiscordBot.Helpers;
using DiscordBot.Helpers.Interfaces;
using DiscordBot.Services;
using DSharpPlus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace DiscordBot
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            await CreateHostBuilder(args).Build().RunAsync();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            var env = new ConfigurationBuilder().AddEnvironmentVariables().AddCommandLine(args).Build().GetValue<string>("Environment");
            var builder = new HostBuilder();
            builder.UseEnvironment(env);
            builder.ConfigureAppConfiguration(configBuilder => ConfigureAppConfiguration(configBuilder, args, env));
            builder.ConfigureLogging(ConfigureLogging);
            builder.ConfigureServices(ConfigureServices);

            return builder;
        }

        private static void ConfigureAppConfiguration(IConfigurationBuilder configBuilder, string[] args, string env)
        {
            configBuilder
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env}.json", optional: true, reloadOnChange: true)
                .AddUserSecrets<Program>()
                .AddEnvironmentVariables()
                .AddCommandLine(args);
        }

        private static void ConfigureServices(HostBuilderContext hostContext, IServiceCollection services)
        {
            var config = hostContext.Configuration;
            services.AddTransient(_ => new DiscordClient(new DiscordConfiguration
            {
                Token = config["Discord:Token"],
                TokenType = TokenType.Bot
            }));

            services.AddTransient<IDiscordCommand, PingCommand>();
            services.AddTransient<IDiscordCommand, EchoCommand>();
            services.AddTransient<IDiscordCommand, QuoteCommand>();
            services.Configure<DiscordOptions>(config.GetSection("Discord"));
            services.AddHostedService<DiscordService>();

            services.AddTransient<IQuoteHelper, QuoteHelper>();
        }

        private static void ConfigureLogging(HostBuilderContext hostContext, ILoggingBuilder loggingBuilder)
        {
            loggingBuilder.AddConfiguration(hostContext.Configuration.GetSection("Logging"));
            loggingBuilder.AddConsole();
        }
    }
}

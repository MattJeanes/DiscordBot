using System.ComponentModel.DataAnnotations;

namespace DiscordBot.Data.Options
{
    public class DiscordOptions
    {
        [Required]
        public string Token { get; set; }

        [Required]
        public string CommandPrefix { get; set; }
    }
}

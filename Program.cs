using Discord;
using Discord.WebSocket;
using maintenance_bot;

public class Progam
{
    private static DiscordSocketClient _client;

    private static Task Log(LogMessage msg)
    {
        Console.WriteLine(msg.ToString());
        return Task.CompletedTask;
    }

    private static async Task SlashCommandHandler(SocketSlashCommand command)
    {
        string? support_url = Config.useCompiledConfig ? Config.guild_url : Environment.GetEnvironmentVariable("GUILD_URL");
        EmbedFieldBuilder supportField = new EmbedFieldBuilder()
            .WithName("Support")
            .WithValue($"If you have any questions or suggestions, join our [support server]({support_url})");

        EmbedBuilder embedBuilder = new EmbedBuilder()
            .WithCurrentTimestamp()
            .WithTitle("Under maintenance")
            .WithDescription("This bot is currently under maintenance!")
            .AddField(supportField)
            .WithFooter("Maintenance bot by riley0122");

        await command.RespondAsync(embed: embedBuilder.Build(), ephemeral: true);
    }

    public static async Task Main()
    {
        _client = new();
        _client.Log += Log;

        var token = Config.useCompiledConfig ? Config.token : Environment.GetEnvironmentVariable("TOKEN");
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await _client.SetGameAsync("Under maintenance!", null, ActivityType.CustomStatus);
        await _client.SetStatusAsync(UserStatus.DoNotDisturb);

        _client.SlashCommandExecuted += SlashCommandHandler;

        await Task.Delay(-1);
    }
}

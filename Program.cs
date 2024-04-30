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

    public static async Task Main()
    {
        _client = new();
        _client.Log += Log;

        var token = Config.useCompiledConfig ? Config.token : Environment.GetEnvironmentVariable("TOKEN");
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
}

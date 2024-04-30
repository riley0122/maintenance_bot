using Discord;
using Discord.WebSocket;

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

        var token = Environment.GetEnvironmentVariable("TOKEN");
        await _client.LoginAsync(TokenType.Bot, token);
        await _client.StartAsync();

        await Task.Delay(-1);
    }
}

namespace maintenance_bot
{
    internal static class Config
    {
        // IF THIS FILE WAS NOT COMPILED IN, OR NOT USED, PLEASE SET THE
        // "TOKEN" AND THE "GUILD_URL" VARIABLES AS ENVIROMENT VARIABLES
        public static string token = "YOUR_TOKEN";
        public static string guild_url = "https://discord.gg/YOUR_INVITE";

        // CHANGE THIS TO true IF YOU WANT TO USE YOUR CONFIG
        public static bool useCompiledConfig = false;
    }
}

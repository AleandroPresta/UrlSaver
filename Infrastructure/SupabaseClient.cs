using Supabase;

namespace UrlSaver.Infrastructure;

public class SupabaseClient
{
    public Client supabase { get; init; }

    public SupabaseClient()
    {
        DotNetEnv.Env.Load();
        var url =
            DotNetEnv.Env.GetString("SUPABASE_URL")
            ?? throw new ArgumentNullException("SUPABASE_URL is null");
        var key =
            DotNetEnv.Env.GetString("SUPABASE_KEY")
            ?? throw new ArgumentNullException("SUPABASE_KEY is null");

        var options = new SupabaseOptions { AutoConnectRealtime = false };
        supabase = new Client(url, key, options);
        supabase.InitializeAsync();
    }
}

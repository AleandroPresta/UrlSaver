using Supabase;

namespace UrlSaver.Infrastructure;

public class SupabaseClient
{
    public Client supabase { get; init; }

    public SupabaseClient()
    {
        var url =
            Environment.GetEnvironmentVariable("SUPABASE_URL")
            ?? throw new ArgumentNullException("SUPABASE_URL is null");
        var key =
            Environment.GetEnvironmentVariable("SUPABASE_KEY")
            ?? throw new ArgumentNullException("SUPABASE_KEY is null");

        var options = new Supabase.SupabaseOptions { AutoConnectRealtime = true };
        supabase = new Client(url, key, options);
        supabase.InitializeAsync();
    }
}

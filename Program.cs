using DotNetEnv;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

Env.Load();
var url = Env.GetString("SUPABASE_URL");
var key = Env.GetString("SUPABASE_KEY");

if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(key))
{
    Console.Error.WriteLine(
        "Supabase config is missing. Set Supabase:Url and Supabase:AnonKey in wwwroot/appsettings.json or Netlify env vars."
    );
    url = "https://example.invalid";
    key = "invalid";
}
else
{
    Console.WriteLine($"Using Supabase Url: {url}");
}

var options = new Supabase.SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };

builder.Services.AddSingleton(_ => new Supabase.Client(url, key, options));
builder.Services.AddScoped<GetBookmarksService>();
builder.Services.AddScoped<GetBookmarkService>();
builder.Services.AddScoped<CreateBookmarkService>();
builder.Services.AddScoped<DeleteBookmarkService>();
builder.Services.AddScoped<EditBookmarkService>();

await builder.Build().RunAsync();

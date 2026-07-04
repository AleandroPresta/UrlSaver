var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

Console.WriteLine("Starting up...");

var url = builder.Configuration["Supabase:Url"];
var key = builder.Configuration["Supabase:Key"];

if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(key))
{
    Console.Error.WriteLine("Supabase config is missing.");
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

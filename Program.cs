using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

var url = builder.Configuration["Supabase:Url"];
var key = builder.Configuration["Supabase:AnonKey"];

if (string.IsNullOrWhiteSpace(url) || string.IsNullOrWhiteSpace(key))
{
    Console.Error.WriteLine(
        "Supabase config is missing. Set Supabase:Url and Supabase:AnonKey in wwwroot/appsettings.json or Netlify env vars."
    );
    url = "https://example.invalid";
    key = "invalid";
}

var options = new Supabase.SupabaseOptions { AutoRefreshToken = true, AutoConnectRealtime = true };

builder.Services.AddSingleton(_ => new Supabase.Client(url, key, options));
builder.Services.AddScoped<GetBookmarksService>();
builder.Services.AddScoped<GetBookmarkService>();
builder.Services.AddScoped<CreateBookmarkService>();
builder.Services.AddScoped<DeleteBookmarkService>();
builder.Services.AddScoped<EditBookmarkService>();

await builder.Build().RunAsync();

using UrlSaver.Components;
using UrlSaver.Features.CreateBookmark;
using UrlSaver.Features.DeleteBookmark;
using UrlSaver.Features.EditBookmark;
using UrlSaver.Features.GetBookmarks;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();

DotNetEnv.Env.Load();
var url = DotNetEnv.Env.GetString("SUPABASE_URL");
var key = DotNetEnv.Env.GetString("SUPABASE_KEY");
var options = new Supabase.SupabaseOptions
{
    AutoRefreshToken = true,
    AutoConnectRealtime = true,
    // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
};

// Note the creation as a singleton.
builder.Services.AddSingleton(provider => new Supabase.Client(url, key, options));
builder.Services.AddScoped<GetBookmarksService>();
builder.Services.AddScoped<CreateBookmarkService>();
builder.Services.AddScoped<DeleteBookmarkService>();
builder.Services.AddScoped<EditBookmarkService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>().AddInteractiveServerRenderMode();

app.Run();

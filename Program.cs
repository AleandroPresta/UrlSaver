using UrlSaver.Components;
using UrlSaver.Features.CreateBookmark;
using UrlSaver.Features.DeleteBookmark;
using UrlSaver.Features.EditBookmark;
using UrlSaver.Features.GetBookmarks;
using UrlSaver.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<SupabaseClient>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<SupabaseClient>().supabase);
builder.Services.AddScoped<GetBookmarksService>();
builder.Services.AddScoped<GetBookmarksRepository>();
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
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class GetBookmarksService
{
    private readonly Supabase.Client _supabase;

    public GetBookmarksService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<UrlBookmark>> GetBookmarks()
    {
        try
        {
            var result = await _supabase.From<UrlBookmark>().Get();
            return result.Models ?? [];
        }
        catch
        {
            return [];
        }
    }
}

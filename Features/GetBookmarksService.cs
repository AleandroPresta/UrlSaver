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
        var result = await _supabase.From<UrlBookmark>().Get();
        return result.Models ?? [];
    }
}

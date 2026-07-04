using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class GetBookmarksRepository
{
    private readonly Supabase.Client _supabase;

    public GetBookmarksRepository(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<UrlBookmark>> GetBookmarksAsync(int pageNo, int pageSize)
    {
        var result = await _supabase.From<UrlBookmark>().Get();
        return result.Models;
    }
}

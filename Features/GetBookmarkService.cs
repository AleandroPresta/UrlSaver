using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmark;

public class GetBookmarkService
{
    private readonly Supabase.Client _supabase;

    public GetBookmarkService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<UrlBookmark?> GetBookmarkById(int id)
    {
        // A result can be fetched like so.
        var result = await _supabase.From<UrlBookmark>().Select(x => new object[] { x.Id }).Get();
        return result.Model ?? null;
    }
}

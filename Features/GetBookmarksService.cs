namespace UrlSaver.Features.GetBookmarks;

public class GetBookmarksService
{
    private readonly Supabase.Client _supabase;

    public GetBookmarksService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<List<UrlBookmark>> GetBookmarks(string? searchTerm, int pageNo, int pageSize)
    {
        var query = _supabase.From<UrlBookmark>();
        if (!string.IsNullOrEmpty(searchTerm))
        {
            _ = query.Where(x =>
                x.Name!.ToLower().Contains(searchTerm.ToLower())
                || x.Description!.ToLower().Contains(searchTerm.ToLower())
                || x.Url!.ToLower().Contains(searchTerm.ToLower())
            );
        }
        var result = await query.Get();
        return result.Models ?? [];
    }
}

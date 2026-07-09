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
        if (!string.IsNullOrEmpty(searchTerm))
        {
            var query = _supabase
                .From<UrlBookmark>()
                .Filter(
                    x => x.Name!.ToLower(),
                    Supabase.Postgrest.Constants.Operator.ILike,
                    $"%{searchTerm.ToLower()}%"
                );
            var searchedItems = await query.Get();
            return searchedItems.Models ?? [];
        }
        var result = await _supabase.From<UrlBookmark>().Get();
        return result.Models ?? [];
    }
}

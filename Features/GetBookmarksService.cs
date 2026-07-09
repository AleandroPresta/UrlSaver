using Microsoft.Extensions.Options;

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
        var query = _supabase.From<UrlBookmark>().Select("*");
        // Applying search
        if (!string.IsNullOrEmpty(searchTerm))
        {
            query = query.Filter(
                x => x.Name!.ToLower(),
                Supabase.Postgrest.Constants.Operator.ILike,
                $"%{searchTerm.ToLower()}%"
            );
        }

        // Applying pagination
        if (pageNo >= 0 && pageSize >= 0)
        {
            //Applying pagination
            int from = (pageNo - 1) * pageSize;
            int to = from + pageSize - 1;

            query = query.Range(from, to);
        }

        // Applying sorting
        query = query.Order("created_at", Supabase.Postgrest.Constants.Ordering.Descending);
        var result = await query.Get();
        return result.Models ?? [];
    }
}

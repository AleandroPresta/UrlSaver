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
        var result = await _supabase
            .From<UrlBookmark>()
            .Filter("id", Supabase.Postgrest.Constants.Operator.Equals, id)
            .Get();
        return result.Model ?? null;
    }
}

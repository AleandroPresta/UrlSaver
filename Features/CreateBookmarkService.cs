using UrlSaver.Domain;

namespace UrlSaver.Features.CreateBookmark;

public class CreateBookmarkService
{
    private readonly Supabase.Client _supabase;

    public CreateBookmarkService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task New(UrlBookmark bookmark)
    {
        await _supabase.From<UrlBookmark>().Insert(bookmark);
    }
}

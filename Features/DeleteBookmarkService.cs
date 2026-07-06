namespace UrlSaver.Features.DeleteBookmark;

public class DeleteBookmarkService
{
    private readonly Supabase.Client _supabase;

    public DeleteBookmarkService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task<int> Delete(int id)
    {
        await _supabase.From<UrlBookmark>().Where(x => x.Id == id).Delete();
        return id;
    }
}

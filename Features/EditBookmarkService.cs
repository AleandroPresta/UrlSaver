namespace UrlSaver.Features.EditBookmark;

public class EditBookmarkService
{
    private readonly Supabase.Client _supabase;

    public EditBookmarkService(Supabase.Client supabase)
    {
        _supabase = supabase;
    }

    public async Task Edit(UrlBookmark updatedBookmark)
    {
        var currentBookmark = await _supabase
            .From<UrlBookmark>()
            .Where(x => x.Id == updatedBookmark.Id)
            .Single();
        if (!string.IsNullOrWhiteSpace(updatedBookmark?.Name))
        {
            currentBookmark.Name = updatedBookmark.Name;
        }
        if (!string.IsNullOrWhiteSpace(updatedBookmark?.Description))
        {
            currentBookmark.Description = updatedBookmark.Description;
        }
        if (!string.IsNullOrWhiteSpace(updatedBookmark?.Url))
        {
            currentBookmark.Url = updatedBookmark.Url;
        }
        await currentBookmark!.Update<UrlBookmark>();
    }
}

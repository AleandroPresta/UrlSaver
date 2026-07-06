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
        if (!string.IsNullOrWhiteSpace(currentBookmark?.Name))
        {
            currentBookmark.Name = updatedBookmark.Name;
        }
        if (!string.IsNullOrWhiteSpace(currentBookmark?.Description))
        {
            currentBookmark.Description = updatedBookmark.Description;
        }
        if (!string.IsNullOrWhiteSpace(currentBookmark?.Url))
        {
            currentBookmark.Url = updatedBookmark.Url;
        }
        await currentBookmark!.Update<UrlBookmark>();
    }
}

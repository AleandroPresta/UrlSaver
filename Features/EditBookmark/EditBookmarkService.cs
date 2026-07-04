using UrlSaver.Domain;

namespace UrlSaver.Features.EditBookmark;

public class EditBookmarkService
{
    public EditBookmarkService() { }

    public async Task Edit(UrlBookmark bookmark)
    {
        Console.WriteLine($"Editing bookmark with Id: {bookmark.Id}");
    }
}

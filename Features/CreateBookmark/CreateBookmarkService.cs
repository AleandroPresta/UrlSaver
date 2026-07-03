using UrlSaver.Domain;

namespace UrlSaver.Features.CreateBookmark;

public class CreateBookmarkService
{
    public CreateBookmarkService() { }

    public async Task New(UrlBookmark bookmark)
    {
        Console.WriteLine($"Name: {bookmark.Name}");
    }
}

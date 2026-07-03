using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class InMemoryRepository : IGetBookmarksRepository
{
    private readonly List<UrlBookmark> _bookmarks =
    [
        new UrlBookmark
        {
            Name = "Google",
            Url = "https://www.google.com",
            Description =
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
        },
        new UrlBookmark
        {
            Name = "Google",
            Url = "https://www.google.com",
            Description =
                "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
        },
    ];

    public List<UrlBookmark> GetBookmarks(int pageNo, int pageSize)
    {
        return _bookmarks;
    }
}

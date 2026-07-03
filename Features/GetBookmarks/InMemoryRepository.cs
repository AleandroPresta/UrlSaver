using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class InMemoryRepository : IGetBookmarksRepository
{
    private readonly List<UrlBookmark> _bookmarks =
    [
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
        new UrlBookmark(
            "Google",
            "https://www.google.com",
            "Lorem ipsum and some other shit.",
            ["Search", "Results"]
        ),
    ];

    public List<UrlBookmark> GetBookmarks(int pageNo, int pageSize)
    {
        return _bookmarks;
    }
}

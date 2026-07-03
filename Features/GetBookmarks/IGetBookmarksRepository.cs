using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public interface IGetBookmarksRepository
{
    public List<UrlBookmark> GetBookmarks(int pageNo, int pageSize);
}

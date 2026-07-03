using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class GetBookmarksService
{
    private readonly IGetBookmarksRepository _repository;

    public GetBookmarksService(IGetBookmarksRepository repository)
    {
        _repository = repository;
    }

    public List<UrlBookmark> GetBookmarks(GetBookmarksRequest request)
    {
        List<UrlBookmark> items = _repository.GetBookmarks(request.PageNo, request.PageSize);
        return items ?? [];
    }
}

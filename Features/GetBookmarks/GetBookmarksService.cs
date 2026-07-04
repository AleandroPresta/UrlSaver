using UrlSaver.Domain;

namespace UrlSaver.Features.GetBookmarks;

public class GetBookmarksService
{
    private readonly GetBookmarksRepository _repository;

    public GetBookmarksService(GetBookmarksRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<UrlBookmark>> GetBookmarks(GetBookmarksRequest request)
    {
        List<UrlBookmark> items = await _repository.GetBookmarksAsync(
            request.PageNo,
            request.PageSize
        );
        return items ?? [];
    }
}

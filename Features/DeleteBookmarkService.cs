namespace UrlSaver.Features.DeleteBookmark;

public class DeleteBookmarkService
{
    public DeleteBookmarkService() { }

    public async Task<int> Delete(int id)
    {
        Console.WriteLine($"Deleting bookmark with Id: {id}");
        return id;
    }
}

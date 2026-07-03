namespace UrlSaver.Domain;

public record UrlBookmark(string Name, string Url, string? Description, List<string> Tags);

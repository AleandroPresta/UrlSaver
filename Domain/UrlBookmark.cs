using System.ComponentModel.DataAnnotations;

namespace UrlSaver.Domain;

public class UrlBookmark
{
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2-50 characters")]
    public string? Name { get; set; }

    [Url(ErrorMessage = "Please enter a valid URL")]
    [Required(ErrorMessage = "Url is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2-50 characters")]
    public string? Url { get; set; }
    public string? Description { get; set; }
    public List<string> Tags { get; set; } = [];
}

using System.ComponentModel.DataAnnotations;
using Supabase.Postgrest.Attributes;
using Supabase.Postgrest.Models;

namespace UrlSaver.Domain;

[Table("UrlBookmarks")]
public class UrlBookmark : BaseModel
{
    [PrimaryKey]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [Required(ErrorMessage = "Name is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2-50 characters")]
    public string? Name { get; set; }

    [Column("url")]
    [Url(ErrorMessage = "Please enter a valid URL")]
    [Required(ErrorMessage = "Url is required")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be 2-50 characters")]
    public string? Url { get; set; }

    [Column("description")]
    public string? Description { get; set; }
}

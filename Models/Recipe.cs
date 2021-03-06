using System.ComponentModel.DataAnnotations;

namespace AllSpiceCSharp.Models
{
    public class Recipe
    {
    public int Id { get; set; }
    public string CreatedAt { get; set; }
    public string UpdatedAt { get; set; }
    public string Description { get; set; }
    [Required]
    [MinLength(3)]
    [MaxLength(25)]
    public string Title { get; set; }
    
    [Range (1, 2880)]
    public int CookTime { get; set; } = 1;
    [Range (1, 2880)]
    public int PrepTime { get; set; } = 1;
    public string CreatorId { get; set; }
    // TODO populate Creator
    public Profile Creator { get; set; }
    }
}
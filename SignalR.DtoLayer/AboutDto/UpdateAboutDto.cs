using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.AboutDto;

public class UpdateAboutDto
{
    public int AboutId { get; set; }
    [Required, MinLength(1), MaxLength(150)]
    public string? Title { get; set; }
    [Required, MinLength(1), MaxLength(150)]
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}

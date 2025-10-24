using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.SocialMediaDto;

public class CreateSocialMediaDto
{
    [Required,MinLength(2)]
    public string Title { get; set; }
    [Required]
    public string Url { get; set; }
    [Required]
    public string Icon { get; set; }
}

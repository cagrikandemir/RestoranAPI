using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.DiscountDto;

public class CreateDiscountDto
{
    [Required,MinLength(2)]
    public string? Title { get; set; }
    [Required, MinLength(2)]
    public string? Despcription { get; set; }
    [Required]
    public int Amount { get; set; }
    public string? ImageUrl { get; set; }
    public bool Status { get; set; } = false;

}

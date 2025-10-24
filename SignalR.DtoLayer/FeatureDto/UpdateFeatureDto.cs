using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.FeatureDto;

public class UpdateFeatureDto
{
    public int FeatureId { get; set; }
    [MinLength(2), Required]
    public string? Title1 { get; set; }
    [MinLength(2), Required]
    public string? Despcription1 { get; set; }
    [MinLength(2)]
    public string? Title2 { get; set; }
    [MinLength(2)]
    public string? Despcription2 { get; set; }
    [MinLength(2)]
    public string? Title3 { get; set; }
    [MinLength(2)]
    public string? Despcription3 { get; set; }
}

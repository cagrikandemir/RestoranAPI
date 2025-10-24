using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.ProductDto;

public class CreateProductDto
{
    [Required, MinLength(2)]
    public string? ProductName { get; set; }
    [Required, MinLength(2)]
    public string? Despcription { get; set; }
    [Required]
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool ProductStatus { get; set; }
    [Required]
    public int CategoryId { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.ProductDto;

public class UpdateProductDto
{
    public int ProductId { get; set; }
    [ MinLength(2)]
    public string? ProductName { get; set; }
    [ MinLength(2)]
    public string? Despcription { get; set; }
    public decimal Price { get; set; }
    public string? ImageUrl { get; set; }
    public bool ProductStatus { get; set; }
    public int CategoryId { get; set; }
}

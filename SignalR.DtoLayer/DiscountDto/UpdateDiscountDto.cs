namespace SignalR.DtoLayer.DiscountDto;

public class UpdateDiscountDto
{
    public int DiscountId { get; set; }
    public string? Title { get; set; }
    public string? Despcription { get; set; }
    public int Amount { get; set; }
    public string? ImageUrl { get; set; }
}

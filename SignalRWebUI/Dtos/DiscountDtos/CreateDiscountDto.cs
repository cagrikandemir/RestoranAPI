﻿namespace SignalRWebUI.Dtos.DiscountDtos;

public class CreateDiscountDto
{
    public string? Title { get; set; }
    public string? Despcription { get; set; }
    public int Amount { get; set; }
    public string? ImageUrl { get; set; }
}

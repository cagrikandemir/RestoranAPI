﻿namespace SignalR.DtoLayer.AboutDto;

public class UpdateAboutDto
{
    public int AboutId { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}

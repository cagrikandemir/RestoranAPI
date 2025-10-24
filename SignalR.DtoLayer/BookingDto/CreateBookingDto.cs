using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.BookingDto;

public class CreateBookingDto
{
    [Required,MinLength(2), MaxLength(50)]
    public string Name { get; set; }
    [Required,EmailAddress]
    public string Mail { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
    [MaxLength(250)]
    public string? Description { get; set; }
    [Required]
    public string PersonCount { get; set; }
    [Required]
    public DateTime Date { get; set; }
}

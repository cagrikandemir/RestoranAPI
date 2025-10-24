using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.ContactDto;

public class CreateContactDto
{
    [Required,MinLength(3)]
    public string Location { get; set; }
    [Required, Phone]
    public string Phone { get; set; }
    [Required, EmailAddress]
    public string Mail { get; set; }
    [Required, MinLength(2)]
    public string FooterTitle { get; set; }
    [Required, MinLength(2)]
    public string FooterDespcription { get; set; }
    [Required, MinLength(2)]
    public string OpenDays { get; set; }
    [Required, MinLength(2)]
    public string OpenDaysDescription { get; set; }
    [Required, MinLength(2)]
    public string OpenHours { get; set; }
}

using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.NotificationDto;

public class UpdateNotificationDto
{
    public int NotificationId { get; set; }
    [Required]
    public string Type { get; set; }
    [Required]
    public string Icon { get; set; }
    [Required , MinLength(2)]
    public string Description { get; set; }
    [Required]
    public DateTime Date { get; set; }
    public bool Status { get; set; }
}

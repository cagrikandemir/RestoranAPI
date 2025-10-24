using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.MenuTableDto;

public class UpdateMenuTableDto
{
    public int MenuTableId { get; set; }
    [Required, MinLength(2)]
    public string Name { get; set; }
    public bool Status { get; set; }
}

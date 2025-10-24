using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.MenuTableDto;

public class CreateMenuTableDto
{
    [Required,MinLength(2)]
    public string Name { get; set; }
    public bool Status { get; set; }
}

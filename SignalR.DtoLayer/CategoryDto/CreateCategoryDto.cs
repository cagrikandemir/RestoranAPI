using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.CategoryDto;

public class CreateCategoryDto
{
    [MinLength(3), MaxLength(15),Required]
    public string? CategoryName { get; set; }
    public bool CategoryStatus { get; set; } = true;
}

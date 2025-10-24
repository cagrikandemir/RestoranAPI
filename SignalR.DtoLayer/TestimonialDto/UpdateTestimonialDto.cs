using System.ComponentModel.DataAnnotations;

namespace SignalR.DtoLayer.TestimonialDto;

public class UpdateTestimonialDto
{
    public int TestimonialId { get; set; }
    [Required, MinLength(2)]
    public string Name { get; set; }
    [Required, MinLength(2)]
    public string Title { get; set; }
    [Required, MinLength(2)]
    public string Comment { get; set; }
    public string ImageUrl { get; set; }
    public bool Status { get; set; }
}

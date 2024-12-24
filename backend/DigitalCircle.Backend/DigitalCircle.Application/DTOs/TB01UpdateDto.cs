using System.ComponentModel.DataAnnotations;

namespace DigitalCircle.Backend.DigitalCircle.Application.DTOs;

public class TB01UpdateDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string ColText { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace DigitalCircle.Backend.DigitalCircle.Application.DTOs;

public class TB01AddDto
{
    [Required]
    public string ColText { get; set; } = string.Empty;
}

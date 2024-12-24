using System.ComponentModel.DataAnnotations;

namespace DigitalCircle.Backend.DigitalCircle.Application.DTOs;

public class TB01DeleteDto
{
    [Required]
    public int Id { get; set; }
}

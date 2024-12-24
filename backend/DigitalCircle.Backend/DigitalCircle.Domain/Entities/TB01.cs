using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalCircle.Backend.DigitalCircle.Domain.Entities;

public class TB01
{
    [Column("id")]
    public int Id { get; set; }

    [Column("col_texto")]
    public string ColText { get; set; } = string.Empty;

    [Column("col_dt")]
    public DateTime ColDt { get; set; } = DateTime.Now;
}

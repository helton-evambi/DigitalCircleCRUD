using DigitalCircle.Backend.DigitalCircle.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalCircle.Backend.DigitalCircle.Infrastructure.Context;

public class AppDbContext : DbContext
{
    public DbSet<TB01> TB01 { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
}


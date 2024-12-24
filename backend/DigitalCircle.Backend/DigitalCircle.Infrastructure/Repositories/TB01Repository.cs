using DigitalCircle.Backend.DigitalCircle.Domain.Entities;
using DigitalCircle.Backend.DigitalCircle.Domain.Interfaces;
using DigitalCircle.Backend.DigitalCircle.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DigitalCircle.Backend.DigitalCircle.Infrastructure.Repositories;

public class TB01Repository : ITB01Repository
{
    private readonly AppDbContext _context;

    public TB01Repository(AppDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<TB01>> GetAllAsync()
    {
        return await _context.TB01.AsNoTracking()
                                  .Take(10)
                                  .OrderByDescending(t => t.ColDt)
                                  .ToListAsync();
    }

    public async Task<TB01?> GetAsync(Expression<Func<TB01, bool>> predicate)
    {
        return await _context.TB01.AsNoTracking().FirstOrDefaultAsync(predicate);
    }

    public async Task<TB01> CreateAsync(TB01 entity)
    {
        _context.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TB01?> DeleteAsync(TB01 entity)
    {
        if (entity != null)
        {
            _context.TB01.Remove(entity);
            await _context.SaveChangesAsync();
        }

        return entity;
    }

    public async Task<TB01> UpdateAsync(TB01 entity)
    {
        _context.Attach(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return entity;
    }
}

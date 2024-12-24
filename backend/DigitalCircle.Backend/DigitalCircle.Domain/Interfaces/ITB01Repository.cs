using DigitalCircle.Backend.DigitalCircle.Domain.Entities;
using System.Linq.Expressions;

namespace DigitalCircle.Backend.DigitalCircle.Domain.Interfaces;

public interface ITB01Repository
{
    Task<IEnumerable<TB01>> GetAllAsync();
    Task<TB01?> GetAsync(Expression<Func<TB01, bool>> predicate);
    Task<TB01> CreateAsync(TB01 entity);
    Task<TB01> UpdateAsync(TB01 entity);
    Task<TB01?> DeleteAsync(TB01 entity);
}

using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Application.Responses;
namespace DigitalCircle.Backend.DigitalCircle.Application.Interfaces;

public interface ITB01Service
{
    Task<IEnumerable<TB01ReadDto>> GetAll();
    Task<Response> GetById(int id);
    Task<Response> Add(TB01AddDto entityDto);
    Task<Response> Update(TB01UpdateDto entityDto);
    Task<Response> Remove(TB01DeleteDto entityDto);
}

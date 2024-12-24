using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Domain.Entities;

namespace DigitalCircle.Backend.DigitalCircle.Application.Mapping;

public static class TB01DeleteMapping
{
    public static TB01 ToEntity(TB01DeleteDto dto)
    {
        return new TB01
        {
            Id = dto.Id
        };
    }

    public static TB01DeleteDto ToDto(TB01 entity)
    {
        return new TB01DeleteDto
        {
            Id = entity.Id
        };
    }
}

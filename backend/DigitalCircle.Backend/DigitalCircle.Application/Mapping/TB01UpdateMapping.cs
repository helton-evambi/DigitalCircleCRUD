using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Domain.Entities;

namespace DigitalCircle.Backend.DigitalCircle.Application.Mapping;

public static class TB01UpdateMapping
{
    public static TB01 ToEntity(TB01UpdateDto dto)
    {
        return new TB01
        {
            Id = dto.Id,
            ColText = dto.ColText
        };
    }

    public static TB01UpdateDto ToDto(TB01 entity)
    {
        return new TB01UpdateDto
        {
            Id = entity.Id,
            ColText = entity.ColText
        };
    }
}

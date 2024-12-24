using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Domain.Entities;

namespace DigitalCircle.Backend.DigitalCircle.Application.Mapping;

public static class TB01AddMapping
{
    public static TB01 ToEntity(TB01AddDto dto)
    {
        return new TB01
        {
            ColText = dto.ColText
        };
    }

    public static TB01AddDto ToDto(TB01 entity)
    {
        return new TB01AddDto
        {
            ColText = entity.ColText
        };
    }
}

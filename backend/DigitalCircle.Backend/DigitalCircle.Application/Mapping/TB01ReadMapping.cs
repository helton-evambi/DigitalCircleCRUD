using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Domain.Entities;

namespace DigitalCircle.Backend.DigitalCircle.Application.Mapping
{
    public static class TB01ReadMapping
    {
        public static TB01 ToEntity(TB01ReadDto dto)
        {
            return new TB01
            {
                Id = dto.Id,
                ColText = dto.ColText,
                ColDt = dto.ColDt
            };
        }

        public static TB01ReadDto ToDto(TB01 entity)
        {
            return new TB01ReadDto
            {
                Id = entity.Id,
                ColText = entity.ColText,
                ColDt = entity.ColDt
            };
        }
    }
}

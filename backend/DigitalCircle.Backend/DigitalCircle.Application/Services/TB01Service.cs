using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Application.Interfaces;
using DigitalCircle.Backend.DigitalCircle.Application.Mapping;
using DigitalCircle.Backend.DigitalCircle.Application.Responses;
using DigitalCircle.Backend.DigitalCircle.Domain.Interfaces;

namespace DigitalCircle.Backend.DigitalCircle.Application.Services;

public class TB01Service : ITB01Service
{
    private readonly ITB01Repository _repository;
    public TB01Service(ITB01Repository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TB01ReadDto>> GetAll()
    {
        var entities = await _repository.GetAllAsync();
        
        return entities.Select(e => TB01ReadMapping.ToDto(e));
    }

    public async Task<Response> GetById(int id)
    {
        var entity = await _repository.GetAsync(e => e.Id == id);
        if (entity != null) {
            return new Response
            {
                Status = "Success",
                Data = TB01ReadMapping.ToDto(entity)
            };
        }
        return new Response
        {
            Status = "Error",
            Message = "Entidade não encontrada"
        };

    }

    public async Task<Response> Add(TB01AddDto entityDto)
    {
        var entity = TB01AddMapping.ToEntity(entityDto);
        var newEntity = await _repository.CreateAsync(entity);

        if (newEntity != null) {
            return new Response
            {
                Status = "Success",
                Data = newEntity
            };
        }

        return new Response
        {
            Status = "Error"
        };
    }

    public async Task<Response> Remove(TB01DeleteDto entityDto)
    {
        var entity = await _repository.GetAsync(e => e.Id == entityDto.Id);
        if (entity == null)
        {
            return new Response
            {
                Status = "Error",
                Message = "Entidade não encontrada"
            };
        }

        var deletedEntity = TB01DeleteMapping.ToEntity(entityDto);

        var result = await _repository.DeleteAsync(deletedEntity);
        if (result != null) {
            return new Response
            {
                Status = "Success",
                Data = result
            };
        }

        return new Response
        {
            Status = "Error"
        };
    }

    public async Task<Response> Update(TB01UpdateDto entityDto)
    {
        var entity = await _repository.GetAsync(e => e.Id == entityDto.Id);
        if (entity == null)
        {
            return new Response
            {
                Status = "Error",
                Message = "Entidade não encontrada"
            };
        }

        var updatedEntity = TB01UpdateMapping.ToEntity(entityDto);

        var result = await _repository.UpdateAsync(updatedEntity);

        if (result != null)
        {
            return new Response
            {
                Status = "Success",
                Data = result 
            };
        }

        return new Response
        {
            Status = "Error"
        };
    }
}

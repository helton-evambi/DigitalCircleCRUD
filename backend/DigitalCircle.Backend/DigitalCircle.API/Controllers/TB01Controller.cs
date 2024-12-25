using DigitalCircle.Backend.DigitalCircle.Application.DTOs;
using DigitalCircle.Backend.DigitalCircle.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DigitalCircle.Backend.DigitalCircle.API.Controllers;

[Route("tb01")]
[ApiController]
public class TB01Controller : ControllerBase
{
    private readonly ITB01Service _tb01Service;

    public TB01Controller(ITB01Service tb01Service)
    {
        _tb01Service = tb01Service;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<TB01ReadDto>>> GetAll()
    {
        var tb01 = await _tb01Service.GetAll();

        return Ok(tb01);
    }

    [HttpPost("create")]
    public async Task<ActionResult> Post(TB01AddDto tb01Dto)
    {
        var result = await _tb01Service.Add(tb01Dto);
        if (result.Status == "Success")
            return Created("", new { message = "Criado com sucesso" }); 
        return StatusCode(500);
    }

    [HttpPost("delete")]
    public async Task<ActionResult> Delete(TB01DeleteDto entityDto)
    {
        var result = await _tb01Service.Remove(entityDto);

        if (result.Status == "Success")
            return NoContent();

        if (result.Message.Contains("encontrada"))
            return BadRequest(result.Message);

        return StatusCode(500);
    }

    [HttpPost("update")]
    public async Task<ActionResult> Update(TB01UpdateDto entityDto)
    {
        var result = await _tb01Service.Update(entityDto);

        if (result.Status == "Success")
            return NoContent();

        if (result.Message.Contains("encontrada"))
            return BadRequest(result.Message);

        return StatusCode(500);
    }
}

using Dominoes.Application.Services;
using Dominoes.Core;
using Microsoft.AspNetCore.Mvc;

namespace Dominoes.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class JornadaController : ControllerBase
{
    private readonly DominoesService _dominoesService;

    public JornadaController(DominoesService dominoesService)
    {
        _dominoesService = dominoesService;
    }

    /// <summary>
    /// Gets a Jornada given an ID
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpGet("{id}")]
    public ActionResult<Jornada> GetJornadaById(uint id)
    {
        var jornada = _dominoesService.GetJornadaById(id);
        if (jornada is null)
        {
            return NotFound($"Jornada with ID {id} was not found");
        }

        return Ok(jornada);
    }
    
    
}
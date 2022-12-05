using System.Security.Cryptography;
using Dominoes.Api.Mappers;
using Dominoes.Api.Models;
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
    [HttpGet("{id:guid}")]
    public ActionResult<Jornada> GetJornadaById(Guid id)
    {
        var jornada = _dominoesService.GetJornadaById(id);
        if (jornada is null)
        {
            return NotFound($"Jornada with ID {id} was not found");
        }

        return Ok(jornada);
    }

    /// <summary>
    /// Creates a Jornada given a jornada model
    /// </summary>
    /// <param name="jornadaModel"></param>
    /// <returns></returns>
    [HttpPost]
    public ActionResult<Jornada> CreateJornada(JornadaModel jornadaModel)
    {
        var jornada = _dominoesService.CreateJornada(jornadaModel.ToEntity());
        return CreatedAtAction(nameof(GetJornadaById), new {id = jornada.Id}, jornada);
    }


    /// <summary>
    /// Creates a Jornada given a jornada model
    /// </summary>
    /// <param name="jornadaId"></param>
    /// <param name="playerModel"></param>
    /// <returns></returns>
    [HttpPost("{jornadaId:guid}/Player")]
    public ActionResult<Player> CreatePlayerOnJornada(Guid jornadaId,PlayerModel playerModel)
    {
        var player = _dominoesService.CreatesPlayerOnJornada(jornadaId,playerModel.ToEntity()); 
        return StatusCode(201, player);
    }

}
using Microsoft.AspNetCore.Mvc;
using Andhy_P1_P4.Services;
using Andhy_P1_P4.Models;

namespace Andhy_P1_P4.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AutoresController (AutoresService autoresService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> SaveAsync(AutoresRecordSet Autor)
    {
        var resultado = await autoresService.SaveAsync(Autor);

        if (resultado == false)
            NotFound ("No Se pudo Guardar el Autor");

      
        return Ok(Autor);
    }

    [HttpPut ("{id}")]

    public async Task<IActionResult> UpdateAsync(int id, AutoresRecordSet autor)
    {
        var resultado = await autoresService.UpdateAsync(id, autor.Nombres, autor.Nacionalidad, autor.FechaNacimiento, autor.Sueldo);

        if (resultado == false)
            return NotFound("El autor no existe");

        var autorActualizado = await autoresService.GetByIdAsync(id);

        return Ok(autorActualizado);

    }

    [HttpDelete ("{id}")]

    public async Task<IActionResult> DeletByIdAsync (int id) 
    {
        var resultado = await autoresService.DeletByIdAsync (id);

        if (resultado == false)
            return NotFound("No se encuntra el Autor Selecionado");

        if (resultado == true)
            return Ok("Autor eliminado correctamente");

        return Ok(resultado);
    }

    [HttpGet]
    public async Task<IActionResult> GetListAsync ()
    {
        var resultado = await autoresService.GetListAsync();

        return Ok(resultado);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var resultado = await autoresService.GetByIdAsync (id);

        if (resultado == null)
            return NotFound("El autor no existe");

        return Ok(resultado);
    }


}

using Microsoft.AspNetCore.Mvc;
using Andhy_P1_P4.Services;
using Andhy_P1_P4.Models;

namespace Andhy_P1_P4.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class AutorController (AutoresService autoresService) : ControllerBase
{
    [HttpPost]
    public async Task <IActionResult> SaveAsync (AutoresRecordSet autor)
    {
        var resultado = await autoresService.SaveAsync (autor);

        return Ok(resultado);
    }

    [HttpPut ("{id : int}")]

    public async Task<IActionResult> UpdateAsync(int id, AutoresRecordSet autor)
    {
        var resultado = await autoresService.UpdateAsync(id, autor.Nombre, autor.Nacionalidad, autor.FechaNacimiento, autor.Sueldo);

        return Ok(resultado);
    }

    [HttpDelete ("borrar/ {id : int}")]

    public async Task<IActionResult> DeletByIdAsync (int id) 
    {
        var resultado = await autoresService.DeletByIdAsync (id);

        if (resultado == false)
            NotFound("No se encuntra el Autor Selecionado");

        if (resultado == true)
            return Ok("Autor eliminado correctamente");

        return Ok(resultado);
    }

    [HttpGet("lista")]
    public async Task<IActionResult> GetListAsync ()
    {
        var resultado = autoresService.GetListAsync();

        return Ok(resultado);
    }

    [HttpGet("lista/ {id : int}")]
    public async Task<IActionResult> GetByIdAsync(int id)
    {
        var resultado = autoresService.GetByIdAsync (id);

        return Ok(resultado);
    }


}

using System.ComponentModel.DataAnnotations;

namespace Andhy_P1_P4.Models;

public record AutoresRecordGet ( long IdAutor, string Nombres, string Nacionalidad, string FechaNacimiento, long Sueldo);

public record AutoresRecordSet ( string Nombres, string Nacionalidad, string FechaNacimiento, long Sueldo);



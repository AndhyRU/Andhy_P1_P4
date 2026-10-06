using System.ComponentModel.DataAnnotations;

namespace Andhy_P1_P4.Models;

public record AutoresRecordGet ( int IdAutor, string Nombre, string Nacionalidad, DateOnly FechaNacimiento, int Sueldo);

public record AutoresRecordSet ( string Nombre, string Nacionalidad, DateOnly FechaNacimiento, int Sueldo);



using System.ComponentModel.DataAnnotations;

namespace Andhy_P1_P4.Models;

public record AutoresRecordGet ( int IdAutor, string Nombre, string nacionalidad, DateOnly FechaNacimiento, int Sueldo);

public record AutoresRecordSet ( string Nombre, string nacionalidad, DateOnly FechaNacimiento, int Sueldo);



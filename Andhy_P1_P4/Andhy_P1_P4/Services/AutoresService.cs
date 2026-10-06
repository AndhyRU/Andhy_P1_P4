using Andhy_P1_P4.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace Andhy_P1_P4.Services;

public class AutoresService (IConfiguration configuration)
{
    private readonly string _connectionString =
        configuration.GetConnectionString("Coneccion");

    private SqliteConnection CreateConnecion =>
        new SqliteConnection(_connectionString);

    public async Task InitializeAsync()
    {
        const string sql = @"CREATE TABLE IF NOT NOT EXISTS Autores (
              IdAutor INTEGER PRIMARY KEY AUTOINCREMENT,
              Nombre TEXT NOT NULL,
              Nacionalidad TEXT NOT NULL, 
              FechaNacimiento TEXT NOT NULL,
              Sueldo INTEGER NOT NULL)";

        var connection = CreateConnecion;

        await connection.ExecuteAsync(sql);
    }

    public async Task<bool> SaveAsync(AutoresRecordSet Autor)
    {
        const string sql = @"INSERT INTO Autores (Nombre, Nacionalidad, Fechanacimiento, Sueldo)
        VALUES (@Nombre, @Nacionalidad, @FechaNacimiento, @Sueldo)";

        var connection = CreateConnecion;

        int lista = await connection.ExecuteAsync(sql, Autor);

        return lista > 0;
    }

    public async Task<IEnumerable<AutoresRecordGet>> GetListAsync ()
    {
        const string sql = @"SELECT IdAutor, Nombre, Nacionalidad, FechaNacimiento, Sueldo FROM Autores ";

        var connection = CreateConnecion;

        return await connection.QueryAsync<AutoresRecordGet>(sql);
    }

    public async Task<AutoresRecordGet?> GetByIdAsync(int Id)
    {
        const string sql = @"SELECT IdAutor, Nombre, Nacionalidad, FechaNacimiento, Sueldo FROM Autores WHERE Id = @IdAutores ";

        var connection = CreateConnecion;

        return await connection.QuerySingleAsync<AutoresRecordGet>(sql, new { Id });
    }

    public async Task<bool> DeletByIdAsync(int Id)
    {
        const string sql = @"DELETE FROM Autores WHERE Id = @IdAutores ";

        var connection = CreateConnecion;

        int resultado = await connection.ExecuteAsync(sql, new { Id });

        return resultado > 0;
    }

    public async Task<bool> UpdateAsync(
    int Id,
    string Nombre,
    string Nacionalidad,
    DateOnly FechaNacimiento,
    int Sueldo)
    {
        const string sql = @"UPDATE Autores
                         SET Nombre = @Nombre,
                             Nacionalidad = @Nacionalidad,
                             FechaNacimiento = @FechaNacimiento,
                             Sueldo = @Sueldo
                         WHERE IdAutores = @Id";

        var connection = CreateConnecion;

        int resultado = await connection.ExecuteAsync(
            sql,
            new { Id, Nombre, Nacionalidad, FechaNacimiento, Sueldo });

        return resultado > 0;
    }



}

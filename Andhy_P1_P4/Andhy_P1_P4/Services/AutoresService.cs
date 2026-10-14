using Andhy_P1_P4.Models;
using Dapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Data.Sqlite;

namespace Andhy_P1_P4.Services;

public class AutoresService (IConfiguration configuration)
{
    private readonly string _connectionString =
        configuration.GetConnectionString("Coneccion")!;

    private SqliteConnection CreateConnecion =>
        new SqliteConnection(_connectionString);

    public async Task InitializeAsync()
    {
        const string sql = @"CREATE TABLE IF NOT EXISTS Autores (
              IdAutor INTEGER PRIMARY KEY AUTOINCREMENT,
              Nombres TEXT NOT NULL,
              Nacionalidad TEXT NOT NULL, 
              FechaNacimiento TEXT NOT NULL,
              Sueldo INTEGER NOT NULL)";

        var connection = CreateConnecion;

        await connection.ExecuteAsync(sql);
    }

    public async Task<bool> SaveAsync(AutoresRecordSet Autor)
    {
        const string sql = @"
        INSERT INTO Autores
        (Nombres, Nacionalidad, FechaNacimiento, Sueldo)
        VALUES (@Nombres, @Nacionalidad, @FechaNacimiento, @Sueldo)
        RETURNING IdAutor, Nombres, Nacionalidad, FechaNacimiento, Sueldo";

        using var connection = CreateConnecion;

        var resultado = await connection.ExecuteAsync(sql, Autor);

        return resultado > 0;
    }

    public async Task<IEnumerable<AutoresRecordGet>> GetListAsync ()
    {
        const string sql = @"SELECT IdAutor, Nombres, Nacionalidad, FechaNacimiento, Sueldo FROM Autores ";

        var connection = CreateConnecion;

        return await connection.QueryAsync<AutoresRecordGet>(sql);
    }

    public async Task<AutoresRecordGet?> GetByIdAsync(int Id)
    {
        const string sql = @"SELECT IdAutor, Nombres, Nacionalidad, FechaNacimiento, Sueldo FROM Autores WHERE IdAutor = @Id ";

        var connection = CreateConnecion;

        return await connection.QuerySingleOrDefaultAsync<AutoresRecordGet>(
    sql, new { Id });
    }

    public async Task<bool> DeletByIdAsync(int Id)
    {
        const string sql = @"DELETE FROM Autores WHERE IdAutor = @Id ";

        var connection = CreateConnecion;

        int resultado = await connection.ExecuteAsync(sql, new { Id });

        return resultado > 0;
    }

    public async Task<bool> UpdateAsync(
    int Id,
    string Nombres,
    string Nacionalidad,
    string FechaNacimiento,
    long Sueldo)
    {
        const string sql = @" SELECT * FROM Autores
                         WHERE IdAutor = @Id;

                         UPDATE Autores
                         SET Nombres = @Nombres,
                             Nacionalidad = @Nacionalidad,
                             FechaNacimiento = @FechaNacimiento,
                             Sueldo = @Sueldo
                         WHERE IdAutor = @Id";

        var connection = CreateConnecion;

        int resultado = await connection.ExecuteAsync(
            sql,
            new { Id, Nombres, Nacionalidad, FechaNacimiento, Sueldo });

        return resultado > 0;
    }



}

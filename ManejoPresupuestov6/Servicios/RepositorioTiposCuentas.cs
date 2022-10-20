using Dapper;
using ManejoPresupuestov6.Models;
using Microsoft.Data.SqlClient;

namespace ManejoPresupuestov6.Servicios
{
    public interface IRepositorioTiposCuentas
    {
        Task Crear(TipoCuenta tc);
    }

    //RepositorioTiposCuentas IMPLEMENTA DE RepositorioTiposCuentas
    public class RepositorioTiposCuentas : IRepositorioTiposCuentas
    {
        private readonly string connectionString;

        public RepositorioTiposCuentas(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection");
        }
        public async Task Crear(TipoCuenta tc)
        {
            using var connection = new SqlConnection(connectionString);
            var id = await connection.QuerySingleAsync<int>
                                                ($@"INSERT INTO TipoCuentas (Nombre, UsuarioId, Orden)
                                                values (@Nombre, @UsuarioId, 0);
                                                SELECT SCOPE_IDENTITY();", tc);
            tc.Id = id;

        }
        //validamos si el mismo usuario tiene dos veces el tipo de cuenta
        public async Task<bool> Existe(string nombre, int usuarioId)
        {
            using var connection = new SqlConnection(connectionString);
            var existe = await connection.QueryFirstOrDefaultAsync<int>(
                                            $"SELECT 1 " +
                                            $"FROM TiposCuentas" +
                                            $"WHERE Nombre = @Nombre and UsuarioId = @UsuarioId;", new { nombre, usuarioId });
            return existe == 1;
        }
        //public void Crear(TipoCuenta tc)
        //{
        //    using var connection = new SqlConnection(connectionString);
        //    var id = connection.QuerySingle<int>($@"INSERT INTO TipoCuentas (Nombre, UsuarioId, Orden)
        //                                        values (@Nombre, @UsuarioId, 0);
        //                                        SELECT SCOPE_IDENTITY();", tc);
        //    tc.Id = id;

        //}
    }
}

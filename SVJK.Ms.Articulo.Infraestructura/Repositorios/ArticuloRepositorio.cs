using Dapper;
using MySql.Data.MySqlClient;
using SVJK.Ms.Articulo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace SVJK.Ms.Articulo.Infraestructura.Repositorios
{
    public class ArticuloRepositorio : IArticuloRepositorio
    {
        private MySQLConfiguration _connectionString;
        public ArticuloRepositorio(MySQLConfiguration connectionString)
        {
            _connectionString = connectionString; 
        }

        protected MySqlConnection bdConnection()
        {
            return new MySqlConnection(_connectionString.ConnectionString);
        }                       
             

        public async Task<IEnumerable<Dominio.Entidades.Articulo>> ListarArticulos()
        {
            var bd = bdConnection();
            var sql = @" SELECT id_articulo, id_categoria, codigo, nombre, precio_venta, stock, descripcion FROM articulos";
            return await bd.QueryAsync<Dominio.Entidades.Articulo>(sql, new { });
        }

        public async Task<Dominio.Entidades.Articulo> BuscarArticulo(int id)
        {
            var bd = bdConnection();
            var sql = @"SELECT id_articulo, id_categoria, codigo, nombre, precio_venta, stock, descripcion FROM articulos
                        WHERE id_articulo = @Id";
            return await bd.QueryFirstOrDefaultAsync<Dominio.Entidades.Articulo>(sql, new { Id = id});
        }

        public async Task<bool> InsertarArticulo(Dominio.Entidades.Articulo articulo)
        {
            var bd = bdConnection();
            var sql = @" INSERT INTO articulos (id_categoria, codigo, nombre, precio_venta, stock, descripcion)
                        VALUES (@Categoria, @Codigo, @Nombre, @Precio, @Stock, @Descripcion) ";

            var resultado = await bd.ExecuteAsync(sql, new {articulo.Categoria, articulo.Codigo, articulo.Nombre,
                            articulo.Precio, articulo.Stock, articulo.Descripcion });

            return resultado > 0;
        }

        public async Task<bool> ActualizarArticulo(Dominio.Entidades.Articulo articulo)
        {
            var bd = bdConnection();
            var sql = @"UPDATE articulos SET id_categoria = @Categoria , codigo = @Codigo, nombre = @Nombre, precio_venta = @Precio, 
                               stock = @Stock , descripcion = @Descripcion WHERE id_articulo = @Id";
           var resultado = await bd.ExecuteAsync(sql, new { articulo.Id, articulo.Categoria, articulo.Codigo, articulo.Nombre,
                            articulo.Precio, articulo.Stock, articulo.Descripcion });

            return resultado > 0;
        }

        public async Task<bool> EliminarArticulo(Dominio.Entidades.Articulo articulo)
        {
            var bd = bdConnection();
            var sql = @"DELETE FROM articulos
                        WHERE id_articulo = @Id";
            var resultado =  await bd.ExecuteAsync(sql, new {id = articulo.Id });
            return resultado > 0;

        }
    }
}

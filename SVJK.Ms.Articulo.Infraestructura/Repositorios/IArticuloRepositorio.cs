
using dominio= SVJK.Ms.Articulo.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SVJK.Ms.Articulo.Infraestructura.Repositorios
{
    public interface IArticuloRepositorio
    {

        Task<IEnumerable<dominio.Articulo>> ListarArticulos();
        Task<dominio.Articulo> BuscarArticulo(int id);
        Task<bool> InsertarArticulo(dominio.Articulo articulo);
        Task<bool> ActualizarArticulo(dominio.Articulo articulo);
        Task<bool>  EliminarArticulo(dominio.Articulo articulo);





    }
}

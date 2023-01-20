using System;
using System.Collections.Generic;
using System.Text;

namespace SVJK.Ms.Articulo.Dominio.Entidades
{
    public class Articulo
    {
        public int Id { get; set; }
        public int Categoria { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Stock { get; set; }
        public string Descripcion { get; set; }


    }
}

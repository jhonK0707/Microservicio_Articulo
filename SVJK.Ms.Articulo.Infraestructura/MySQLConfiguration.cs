using System;
using System.Collections.Generic;
using System.Text;

namespace SVJK.Ms.Articulo.Infraestructura
{
    public class MySQLConfiguration
    {

        public MySQLConfiguration(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public string ConnectionString { get; set; }

    }
}

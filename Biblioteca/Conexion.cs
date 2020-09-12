using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
namespace Biblioteca
{
    public class Conexion
    {
        public SqlConnection getConexion()
        {
            try
            {
                string cadena = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True";
                SqlConnection cnn = new SqlConnection(cadena);
                cnn.Open();
                return cnn;

            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}

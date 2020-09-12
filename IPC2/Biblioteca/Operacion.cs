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
    public class Operacion
    {
        public bool Insert(string nombres, string apellidos, string usuario)
        {
            Conexion cn = new Conexion();
            Console.WriteLine(nombres);


            string sql = "insert into info values('"+nombres+"','"+apellidos+"','"+usuario+"')";
            SqlCommand cmd = new SqlCommand(sql, cn.getConexion());

            return true;
        }




    }
}


    



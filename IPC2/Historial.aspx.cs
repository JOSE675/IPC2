using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Historial : System.Web.UI.Page
    {
        string conexion = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";

        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection sqlcon = new SqlConnection(conexion);
            SqlDataAdapter da = new SqlDataAdapter("Select * from Reportes where usuario='" + Login.user + "'", sqlcon);
            DataTable dt = new DataTable();
            da.Fill(dt);
            this.Datos.DataSource = dt;
            Datos.DataBind();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Buscar() == true)
            {
                Response.Redirect("WebForm1.aspx");
            }
            else
            {
                Response.Write("<script>window.alert('Usuario o contraseña incorrecta')</script>");

            }

        }

        public bool Buscar()
        {

            bool resultado = false;
            string sql = string.Empty;
            string usu = usuario.Text;
            string co = Pass.Text;
            string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();

            sql = string.Format("Select usuario,contraseña from info where usuario='{0}' and contraseña='{1}'", usu, co);
            SqlCommand coma = new SqlCommand(sql, sqlcon);
            SqlDataReader reg = null;
            reg = coma.ExecuteReader();
            if (reg.Read() == true)
            {
                resultado = true;
                return resultado;
            }
            else
            {
                return false;
            }
        }
    }
}
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
        public static string nombre;
        public static int iniciado = 0;
        public static string user;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Buscar() == true)
            {
                iniciado = 1;
                user = usuario.Text;
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
            nombre = usu;
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

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }
    }
}
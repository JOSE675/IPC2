using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using IPC2;
using System.Globalization;
using System.Data;

namespace IPC2
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        
        
        public List<string> Pais()
        {
            
            List<string> Paises = new List<string>();
            foreach(CultureInfo informacion in CultureInfo.GetCultures(CultureTypes.SpecificCultures))
            {
                RegionInfo nombre = new RegionInfo(informacion.LCID);
                if (!Paises.Contains(nombre.EnglishName))
                {
                    Paises.Add(nombre.EnglishName);
                    Paises.Sort();
                }
            }
            return Paises;
        }  
        protected void Page_Load(object sender, EventArgs e)
        {
            Pa.DataSource = Pais();
            Pa.DataBind();
            

        }

        

        

        protected void Bo_Click1(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";

            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                string nombre = Nombre.Text;
                string apellido = Ape.Text;
                string usuario = Usi.Text;
                string pass = Con.Text;
                string nac = Nac.Text;
                string pais = Pa.SelectedItem.Text;
                string correo = C.Text;
                sqlCon.Open();
                if (Buscar(usuario, correo) == true)
                {
                    Response.Write("<script>window.alert('El nombre de usuario ya esta registrado, ingrese uno nuevo')</script>");
                    sqlCon.Close();
                }
                else
                {
                    SqlDataAdapter sqlDa = new SqlDataAdapter("insert into info (nombres, apellidos, usuario,contraseña,NAC,pais,correo) values('" + nombre + "','" + apellido + "','" + usuario + "','" + pass + "','" + nac + "','" + pais + "','" + correo + "')", sqlCon);
                    DataTable dtb = new DataTable();
                    sqlDa.Fill(dtb);
                    sqlCon.Close();
                    Response.Write("<script>window.alert('Registro completado :)')</script>");
                    Response.Redirect("WebForm1.aspx");
                }

                

            }
        }

        public bool Buscar(string nombre, string correo)
        {

            bool resultado = false;
            string sql = string.Empty;
            string usu = Usi.Text;
            string co = C.Text;
            string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
           
            sql = string.Format("Select usuario,correo from info where usuario='{0}' or correo='{1}'",usu,co);
            SqlCommand coma = new SqlCommand(sql, sqlcon);
            SqlDataReader reg = null;
            reg = coma.ExecuteReader();
            if (reg.Read()==true)
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
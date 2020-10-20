using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPC2;
using System.Diagnostics;
namespace IPC2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int num = 0;
        public static int p = 0;
        public static string nombre;
        public static int reve;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            Response.Redirect("Registro.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Login.iniciado != 0)
            {
                nombre=FileUpload1.FileName;
                num = 1;
                Response.Redirect("WebForm3.aspx");
                p = 0;
            }
            else
            {
                Response.Write("<script>window.alert('Debe iniciar sesion antes de comenzar')</script>");
            }
            
        }

        protected void Single_Click(object sender, EventArgs e)
        {
            if (Login.iniciado != 0)
            {
                num = 0;
                Response.Redirect("WebForm3.aspx");
                p = 0;
            }
            else
            {
                Response.Write("<script>window.alert('Debe iniciar sesion antes de comenzar')</script>");
            }
        }

        protected void SingleM_Click(object sender, EventArgs e)
        {
            if (Login.iniciado != 0)
            {
                num = 2;
                Response.Redirect("WebForm3.aspx");
                p = 0;
            }
            else{
                Response.Write("<script>window.alert('Debe iniciar sesion antes de comenzar')</script>");
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            reve = 1;
            Response.Write("<script>window.alert('Modo Inverso activado')</script>");
        }
    }
}
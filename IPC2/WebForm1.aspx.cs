using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IPC2;

namespace IPC2
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        public static int num = 0;
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
            num = 1;
            Response.Redirect("WebForm3.aspx");
            
        }

        
        
    }
}
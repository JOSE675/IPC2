using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Seleccion_de_colores : System.Web.UI.Page
    {
        public static List<string> colores1 = new List<string>();
        public static List<string> posiciones1 = new List<string>();
        public static List<string> colores2 = new List<string>();
        public static List<string> posiciones2 = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    colores1.Add(li.Value);
                }
                else
                {
                    colores2.Add(li.Value);
                }
            }
            foreach (ListItem li in Pos.Items)
            {
                if (li.Selected == true)
                {
                    posiciones1.Add(li.Value);
                }
                else
                {
                    posiciones2.Add(li.Value);
                }
            }
            Response.Redirect("Personalizado.aspx");
        }
    }
}
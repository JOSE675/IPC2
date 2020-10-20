using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Personalizado : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["Llave"] = ViewState["Llave"];
            if (ViewState["Llave"] == null)
            {
                int p = 0;
                foreach (string li in Seleccion_de_colores.posiciones1)
                {
                    Button c1 = FindControl(li) as Button;
                    if (c1 != null)
                    {
                        if (Seleccion_de_colores.colores1[p] == "Yellow")
                        {
                            c1.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (Seleccion_de_colores.colores1[p] == "White")
                        {
                            c1.BackColor = System.Drawing.Color.White;
                        }
                        else if (Seleccion_de_colores.colores1[p] == "Red")
                        {
                            c1.BackColor = System.Drawing.Color.Red;
                        }
                        else if (Seleccion_de_colores.colores1[p] == "Black")
                        {
                            c1.BackColor = System.Drawing.Color.Black;
                        }
                    }
                    p++;
                }
                p = 0;
                foreach (string li in Seleccion_de_colores.posiciones2)
                {
                    Button c1 = FindControl(li) as Button;
                    if (c1 != null)
                    {
                        if (Seleccion_de_colores.colores2[p] == "Yellow")
                        {
                            c1.BackColor = System.Drawing.Color.Yellow;
                        }
                        else if (Seleccion_de_colores.colores2[p] == "White")
                        {
                            c1.BackColor = System.Drawing.Color.White;
                        }
                        else if (Seleccion_de_colores.colores2[p] == "Red")
                        {
                            c1.BackColor = System.Drawing.Color.Red;
                        }
                        else if (Seleccion_de_colores.colores2[p] == "Black")
                        {
                            c1.BackColor = System.Drawing.Color.Black;
                        }
                    }
                    p++;
                }


            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void a1_Click(object sender, EventArgs e)
        {

        }

        protected void b1_Click(object sender, EventArgs e)
        {

        }

        protected void c1_Click(object sender, EventArgs e)
        {

        }

        protected void d1_Click(object sender, EventArgs e)
        {

        }

        protected void e1_Click(object sender, EventArgs e)
        {

        }

        protected void f1_Click(object sender, EventArgs e)
        {

        }

        protected void g1_Click(object sender, EventArgs e)
        {

        }

        protected void h1_Click(object sender, EventArgs e)
        {

        }

        protected void a2_Click(object sender, EventArgs e)
        {

        }

        protected void b2_Click(object sender, EventArgs e)
        {

        }

        protected void c2_Click(object sender, EventArgs e)
        {

        }

        protected void d2_Click(object sender, EventArgs e)
        {

        }

        protected void e2_Click(object sender, EventArgs e)
        {

        }

        protected void f2_Click(object sender, EventArgs e)
        {

        }

        protected void g2_Click(object sender, EventArgs e)
        {

        }

        protected void h2_Click(object sender, EventArgs e)
        {

        }

        protected void a3_Click(object sender, EventArgs e)
        {

        }

        protected void b3_Click(object sender, EventArgs e)
        {

        }

        protected void c3_Click(object sender, EventArgs e)
        {

        }

        protected void d3_Click(object sender, EventArgs e)
        {

        }

        protected void e3_Click(object sender, EventArgs e)
        {

        }

        protected void f3_Click(object sender, EventArgs e)
        {

        }

        protected void g3_Click(object sender, EventArgs e)
        {

        }

        protected void h3_Click(object sender, EventArgs e)
        {

        }

        protected void a4_Click(object sender, EventArgs e)
        {

        }

        protected void b4_Click(object sender, EventArgs e)
        {

        }

        protected void c4_Click(object sender, EventArgs e)
        {

        }

        protected void d4_Click(object sender, EventArgs e)
        {

        }

        protected void e4_Click(object sender, EventArgs e)
        {

        }

        protected void f4_Click(object sender, EventArgs e)
        {

        }

        protected void g4_Click(object sender, EventArgs e)
        {

        }

        protected void h4_Click(object sender, EventArgs e)
        {

        }

        protected void a5_Click(object sender, EventArgs e)
        {

        }

        protected void b5_Click(object sender, EventArgs e)
        {

        }

        protected void c5_Click(object sender, EventArgs e)
        {

        }

        protected void d5_Click(object sender, EventArgs e)
        {

        }

        protected void e5_Click(object sender, EventArgs e)
        {

        }

        protected void f5_Click(object sender, EventArgs e)
        {

        }

        protected void g5_Click(object sender, EventArgs e)
        {

        }

        protected void h5_Click(object sender, EventArgs e)
        {

        }

        protected void a6_Click(object sender, EventArgs e)
        {

        }

        protected void b6_Click(object sender, EventArgs e)
        {

        }

        protected void c6_Click(object sender, EventArgs e)
        {

        }

        protected void d6_Click(object sender, EventArgs e)
        {

        }

        protected void e6_Click(object sender, EventArgs e)
        {

        }

        protected void f6_Click(object sender, EventArgs e)
        {

        }

        protected void g6_Click(object sender, EventArgs e)
        {

        }

        protected void h6_Click(object sender, EventArgs e)
        {

        }

        protected void a7_Click(object sender, EventArgs e)
        {

        }

        protected void b7_Click(object sender, EventArgs e)
        {

        }

        protected void c7_Click(object sender, EventArgs e)
        {

        }

        protected void d7_Click(object sender, EventArgs e)
        {

        }

        protected void e7_Click(object sender, EventArgs e)
        {

        }

        protected void f7_Click(object sender, EventArgs e)
        {

        }

        protected void g7_Click(object sender, EventArgs e)
        {

        }

        protected void h7_Click(object sender, EventArgs e)
        {

        }

        protected void a8_Click(object sender, EventArgs e)
        {

        }

        protected void b8_Click(object sender, EventArgs e)
        {

        }

        protected void c8_Click(object sender, EventArgs e)
        {

        }

        protected void d8_Click(object sender, EventArgs e)
        {

        }

        protected void e8_Click(object sender, EventArgs e)
        {

        }

        protected void f8_Click(object sender, EventArgs e)
        {

        }

        protected void g8_Click(object sender, EventArgs e)
        {

        }

        protected void h8_Click(object sender, EventArgs e)
        {

        }
    }
}
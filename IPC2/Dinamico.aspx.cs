using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace IPC2
{
    public partial class Dinamico : System.Web.UI.Page
    {
        public static int x;
        public static List<string> colores1 = new List<string>();
        public static List<string> colores2 = new List<string>();
        public static Botones[,] tablero;
        public static int validar;
        public static string nombre;
        
        public static int cantidad;
        public static int cantidad2;
        public static Botones cuadronuevo;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (x != 0)
            {
                cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
                cantidad2 = Convert.ToInt32(txtCantidad2.Text.Trim());
                cargar(cantidad, cantidad2);
                x = 1;
            }
        }

        protected void btnProceso_Click(object sender, EventArgs e)
        {
            cantidad = Convert.ToInt32(txtCantidad.Text.Trim());
            cantidad2 = Convert.ToInt32(txtCantidad2.Text.Trim());
            foreach (ListItem li in CheckBoxList1.Items)
            {
                if (li.Selected == true)
                {
                    colores1.Add(li.Value);
                    
                }
               
            }
            foreach (ListItem li in Pos.Items)
            {
                if (li.Selected == true)
                {
                    colores2.Add(li.Value);
                }
               
            }
            Response.Redirect("TXtreme.aspx");

           
        }


        private void pruebas(int cantidad, int cantidad2)
        {

            tablero = new Botones[cantidad, cantidad2];

            for (int i = 0; i < cantidad; i++)
            {

                for (int j = 0; j < cantidad2; j++)
                {

                    cuadronuevo = new Botones();
                    cuadronuevo.setColumna(j);
                    cuadronuevo.setFila(i);
                    cuadronuevo.CssClass = "ficha";
                    tablero[i, j] = cuadronuevo;
                }

            }
            cargar(cantidad, cantidad2);
        }
        private void cargar(int cantidad, int cantidad2)
        {
            string p = "width:" + (cantidad2 * 100).ToString() + "px; height:" + ((cantidad * 100) - 50).ToString() + "px; background-color:black";
            HtmlGenericControl NewControl2;
            HtmlGenericControl NewControl;
            NewControl2 = new HtmlGenericControl("div");
            NewControl2.ID = "div";
            NewControl2.Attributes.Add("runat", "server");
            NewControl2.Attributes["style"] = p;
            Page.Form.Controls.Add(NewControl2);

            for (int i = 0; i < cantidad; i++)
            {

                for (int j = 0; j < cantidad2; j++)
                {
                    tablero[i, j].Click += new EventHandler(Ficha_click);
                    NewControl = new HtmlGenericControl("div");
                    NewControl.Attributes.Add("runat", "server");
                    NewControl.Attributes["class"] = "cuadros flotar";
                    NewControl.Controls.Add(tablero[i, j]);
                    NewControl2.Controls.Add(NewControl);


                }
            }
            Page.Form.Controls.Add(NewControl2);


        }
        private void Ficha_click(object sender, EventArgs e)
        {
            Botones Seleccionado = (Botones)sender;
        }
        public class Botones : System.Web.UI.WebControls.Button
        {
            private int columna;
            private int fila;
            private string color;
            private bool ocupado;

            public void setColumna(int columna)
            {
                this.columna = columna;
            }

            public void setFila(int fila)
            {
                this.fila = fila;
            }

            public void setColor(string color)
            {
                this.color = color;
            }

            public void setOcupado(bool ocupado)
            {
                this.ocupado = ocupado;
            }

            public int getColumna()
            {
                return columna;
            }

            public int getFila()
            {
                return fila;
            }

            public string getColor()
            {
                return color;
            }

            public bool getOcupado()
            {
                return ocupado;
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            validar = 1;
            nombre = carga.FileName;
            Response.Redirect("TXtreme.aspx");

        }
    }
}

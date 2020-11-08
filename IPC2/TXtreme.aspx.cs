using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace IPC2
{
    public partial class TXtreme : System.Web.UI.Page
    {
        public static int x;
        public static int z;
        public static int turno;
        public static int colo;
        public static int valida;
        public static int validar2;
        
        public static Botones[,] tablero;
        
        public static int cantidad= Dinamico.cantidad;
        public static int cantidad2 = Dinamico.cantidad2;
        public static int cantidadC;
        public static int cantidad2C;
        public static Botones cuadronuevo;
        LinkedList<Botones> fichita = new LinkedList<Botones>();
        LinkedList<string> vacios = new LinkedList<string>();
        LinkedList<string> posiciones = new LinkedList<string>();
        LinkedList<string> maquina = new LinkedList<string>();
        LinkedList<string> posibles = new LinkedList<string>();
        LinkedList<string> prueb = new LinkedList<string>();
        LinkedList<XmlNodeList> hijos = new LinkedList<XmlNodeList>();
        public int contador2 = 0;
        int Cont = 0;
        int auxiliar = 0;
        int ayuda;
        int pruebas = 0;
        int l = 0;
        int encon = 0;
        int fin = 0;
        int poto = 0;
        string nombre;
        string apellido;
        string nombres;
        int ganadas = 0;
        int perdidas = 0;
        int empatadas = 0;
        public int contador3 = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["vali"] = ViewState["vali"];
           

            if (x != 0)
            {
                if (Dinamico.validar != 1)
                {
                    cantidad = Dinamico.cantidad;
                    cantidad2 = Dinamico.cantidad2;
                    cargar(cantidad, cantidad2);
                }
                else
                {
                    cargar(cantidadC,cantidad2C);
                }
                x = 1;
            }
            else
            {
                validar2 = 0;
                ViewState["vali"] = 1;
                ViewState["turno"] = 0;
                ViewState["verifi"] = -1;
                ViewState["t"] = 0;
                ViewState["t2"] = 0;
                ViewState["blancas"] = 0;
                ViewState["negras"] = 0;
                ViewState["colores"] = 0;
                valida = 0;
                colo = 1;
                if (Dinamico.validar != 1)
                {
                    Pruebas(Dinamico.cantidad, Dinamico.cantidad2);
                }
                else
                {
                    cargar2(Dinamico.nombre);

                }
                x = 1;
            }
            if ((int)ViewState["t2"] == 0)
            {
                mov();
                ViewState["t2"] = 1;
            }
        }
        public void mov()
        {
            string co = "";

            if ((int)ViewState["turno"] == 0)
            {
                if (colo == 1)
                {
                     co = buscar("Red", (int)ViewState["turno"]);
                }
                else if (colo == 3)
                {
                     co = buscar("Yellow", (int)ViewState["turno"]);
                }
                else if (colo == 5)
                {
                     co = buscar("Blue", (int)ViewState["turno"]);
                }
                else if (colo == 7)
                {
                     co = buscar("Orange", (int)ViewState["turno"]);
                }
                else if (colo == 9)
                {
                     co = buscar("LightGreen", (int)ViewState["turno"]);
                }
                if (co != "Posiciones posibles:")
                {
                    fin = 0;

                    Response.Write("<script>console.log('" + co + "')</script>");
                    posibles.Clear();
                }
                else
                {
                    Response.Write("<script>console.log('Sin movimientos posibles')</script>");
                    ViewState["turno"] = 1;
                    turnos();
                    fin++;
                }
            }
            else
            {
                if (colo == 2)
                {
                     co = buscar("Violet", (int)ViewState["turno"]);
                }
                else if (colo == 4)
                {
                     co = buscar("White", (int)ViewState["turno"]);
                }
                else if (colo == 6)
                {
                     co = buscar("Black", (int)ViewState["turno"]);
                }
                else if (colo == 8)
                {
                     co = buscar("LightBlue", (int)ViewState["turno"]);
                }
                else if (colo == 10)
                {
                     co = buscar("Gray", (int)ViewState["turno"]);
                }


                if (co != "Posiciones posibles:")
                {
                    fin = 0;

                    Response.Write("<script>console.log('" + co + "')</script>");
                    posibles.Clear();
                }
                else
                {
                    Response.Write("<script>console.log('Sin movimientos posibles')</script>");
                    ViewState["turno"] = 0;
                    turnos();
                    fin++;
                }
            }
            if (fin == 2)
            {
                int b = 0;
                int n = 0;
                int v = 0;
                foreach (Botones prueba in tablero)
                {
                    if (prueba.getColor() == "Red" || prueba.getColor() == "Yellow" || prueba.getColor() == "Blue" || prueba.getColor() == "Orange" || prueba.getColor() == "LightGreen")
                    {
                        b++;
                    }
                    else if (prueba.getColor() == "Violet" || prueba.getColor() == "White" || prueba.getColor() == "Black" || prueba.getColor() == "LightBlue" || prueba.getColor() == "Gray")
                    {
                        n++;
                    }
                    else
                    {
                        v++;
                    }
                }
                if (Dinamico.inverso == 1)
                {
                    if (b > n)
                    {
                        b = b + v;
                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 0, 1, 0);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 0, 1, 0);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador2: " + n + "')</script>");
                    }
                    else if (b < n)
                    {
                        n = n + v;
                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 1, 0, 0);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 1, 0, 0);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador 2: " + n + "')</script>");
                    }
                    else
                    {

                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 0, 0, 1);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 0, 0, 1);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador 2: " + n + "')</script>");
                    }

                }
                else
                {
                    if (b > n)
                    {
                        b = b + v;
                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 1, 0, 0);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 1, 0, 0);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador 2: " + n + "')</script>");
                    }
                    else if (b < n)
                    {
                        n = n + v;
                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 0, 1, 0);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 0, 1, 0);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador 2: " + n + "')</script>");
                    }
                    else
                    {
                        if (WebForm1.num != 2)
                        {
                            encontrar(Login.user, "JCJ", 0, 0, 1);
                        }
                        else
                        {
                            encontrar(Login.user, "JCM", 0, 0, 1);
                        }
                        Response.Write("<script>console.log('" + "Partida terminada! Jugador 1: " + b + " Jugador 2 : " + n + "')</script>");
                    }

                }
            }
            if (fin == 1)
            {
                mov();
            }
        }
        
        private void Pruebas(int cantidad, int cantidad2)
        {
            fichita = new LinkedList<Botones>();
            tablero = new Botones[cantidad, cantidad2];

            int ascii = 97;
            char a = 'a';
            for (int i = 0; i < cantidad; i++)
            {
                ascii = 97;
                for (int j = 0; j < cantidad2; j++)
                {

                    cuadronuevo = new Botones();
                    cuadronuevo.setFila(i+1);
                    cuadronuevo.setColumna(j+1);
                    
                    cuadronuevo.setId(a + (i+1).ToString());
                    cuadronuevo.CssClass = "ficha";
                    tablero[i, j] = cuadronuevo;
                    if (ascii <= 104)
                    {
                        a = (char)(ascii + 1);
                        ascii++;
                    }
                }
                
            }
            
            cargar(cantidad, cantidad2);
        }
        public void colores(int cantidad, int cantidad2 )
        {
            
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad2; j++)
                {
                    if (tablero[i, j].BackColor.Name == "Red")
                    {
                        tablero[i, j].setColor("Red");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "Yellow")
                    {
                        tablero[i, j].setColor("Yellow");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "Blue")
                    {
                        tablero[i, j].setColor("Blue");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "Orange")
                    {
                        tablero[i, j].setColor("Orange");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "LightGreen")
                    {
                        tablero[i, j].setColor("LightGreen");
                        tablero[i, j].setOcupado(true);
                    }

                    else if (tablero[i, j].BackColor.Name == "Violet")
                    {
                        tablero[i, j].setColor("Violet");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "White")
                    {
                        tablero[i, j].setColor("White");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "Black")
                    {
                        tablero[i, j].setColor("Black");
                        tablero[i, j].setOcupado(true);
                    }
                    else if (tablero[i, j].BackColor.Name == "LightBlue")
                    {
                        tablero[i, j].setColor("LightBlue");
                        tablero[i, j].setOcupado(true);
                    }
                   else if (tablero[i, j].BackColor.Name == "Gray")
                    {
                        tablero[i, j].setColor("Gray");
                        tablero[i, j].setOcupado(true);
                    }


                    else
                    {
                        tablero[i, j].setColor("vacio");
                        tablero[i, j].setOcupado(false);
                    }

                }

            }
                        
        }
        private void cargar(int cantidad, int cantidad2)
        {
            
            string p = "width:" + (cantidad2 * 100).ToString() + "px; height:" + ((cantidad * 100) - 50).ToString() + "px;";
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
            if (x == 0)
            {
                if (Dinamico.validar != 1)
                {
                    coloresIn(cantidad, cantidad2);
                }
                else
                {
                    coloresIn(cantidadC, cantidad2C);
                }
            }
            if (Dinamico.validar != 1)
            {
                colores(cantidad, cantidad2);
            }
            else
            {
                colores(cantidadC, cantidad2C);
            }



        }
        private void coloresIn(int cantidad, int cantidad2)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int v = 0;
            for (int i = (cantidad/2)-1; i < (cantidad/2)+1; i++)
            {
                if (c != 0)
                {
                    v = 1;
                }
                c = 0;

                
                for (int j = (cantidad2/2)-1; j < (cantidad2/2)+1; j++)
                {
                    if (v == 0 && a < Dinamico.colores1.Count && c<Dinamico.colores1.Count)
                    {
                        string color = Dinamico.colores1[a];
                        if ((color == "Red") || (color == "Yellow") || (color == "Blue") || (color == "Orange") || (color == "Green"))
                        {
                            if (color == "Red")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Red;
                            }
                            else if (color == "Yellow")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Yellow;
                            }
                            else if (color == "Blue")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Blue;
                            }
                            else if (color == "Orange")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Orange;
                            }
                            else
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.LightGreen;
                            }
                            v = 1;
                            c++;
                            a++;
                        }

                    }
                    else if (v == 1 && b < Dinamico.colores2.Count && c<Dinamico.colores2.Count)
                    {
                        string color = Dinamico.colores2[b];
                        if ((color == "Violet") || (color == "White") || (color == "Black") || (color == "lightblue") || (color == "Gray"))
                        {
                            if (color == "Violet")
                            {
                                
                                tablero[i, j].BackColor = System.Drawing.Color.Violet;
                            }
                            else if (color == "White")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.White;
                            }
                            else if (color == "Black")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Black;
                            }
                            else if (color == "lightblue")
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.LightBlue;
                            }
                            else
                            {
                                tablero[i, j].BackColor = System.Drawing.Color.Gray;
                            }
                            v = 0;
                            c++;
                            b++;
                        }
                    }

                }
            }
        }
        private void arribay(int x, int y, string color, int p)
        {


            foreach (Botones prueba in tablero)
            {
                
                    if (prueba.getColumna() == x && prueba.getFila() == y && prueba.getColor() != color && (Dinamico.colores1.Contains(prueba.getColor()) == false || (Dinamico.colores2.Contains(prueba.getColor()))==false) && prueba.getOcupado() == true)
                    {
                    if ((prueba.getColor().Equals("Red") || prueba.getColor().Equals("Yellow") || prueba.getColor().Equals("Blue") || prueba.getColor().Equals("Orange") || prueba.getColor().Equals("LightGreen")) && (p == 2 || p == 4 || p == 6 || p == 8 || p == 10))
                    {

                        contador2++;

                    }
                    else if ((prueba.getColor().Equals("Violet") || prueba.getColor().Equals("White") || prueba.getColor().Equals("Black") || prueba.getColor().Equals("LightBlue") || prueba.getColor().Equals("Gray")) && (p == 1 || p == 3 || p == 5 || p == 7 || p == 9))
                    {
                        contador2++;
                    }
                    else
                    {
                        if (contador2 == 0) { 
                        contador2 = 0;
                    }

                        }

                    }
                





            }

        }

        public void pruebadiego(string id, int o, int color)
        {
            int diego = 1;
            int es = 1;
            int puto = 1;
            int culero = 1;
            contador2 = 0;

            foreach (Botones prueba in tablero)
            {
                if (prueba.getId().Equals(id))
                {

                    if (o == 1) {
                        if (color == 1) {
                            prueba.setColor("Red");
                        }
                        else if (color == 3)
                        {
                            prueba.setColor("Yellow");
                        }
                        else if (color == 5)
                        {
                            prueba.setColor("Blue");
                        }
                        else if(color== 7)
                        {
                            prueba.setColor("Orange");
                        }
                        else
                        {
                            prueba.setColor("LightGreen");
                        }
                    }
                    if (o == 0) {
                        if (color == 2)
                        {
                            prueba.setColor("Violet");
                        }
                        else if (color == 4)
                        {
                            prueba.setColor("White");
                        }
                        else if (color == 6)
                        {
                            prueba.setColor("Black");
                        }
                        else if (color == 8)
                        {
                            prueba.setColor("LightBlue");
                        }
                        else
                        {
                            prueba.setColor("Gray");
                        }
                    }
                    diego = prueba.getColumna() + 1;
                    es = prueba.getFila() + 1;
                    puto = prueba.getColumna() - 1;
                    culero = prueba.getFila() - 1;
                    if (Dinamico.validar != 1)
                    {
                        if (diego <= cantidad2 + 1 && es <= cantidad + 1 && puto >= 0 && culero >= 0)
                        {

                            arribay(prueba.getColumna(), es, prueba.getColor(), color);
                            arribay(diego, es, prueba.getColor(), color);
                            arribay(puto, es, prueba.getColor(), color);
                            arribay(diego, prueba.getFila(), prueba.getColor(), color);
                            arribay(puto, prueba.getFila(), prueba.getColor(), color);
                            arribay(prueba.getColumna(), culero, prueba.getColor(), color);
                            arribay(puto, culero, prueba.getColor(), color);
                            arribay(diego, culero, prueba.getColor(), color);


                        }
                    }
                    else
                    {
                        if (diego <= cantidad2C + 1 && es <= cantidadC + 1 && puto >= 0 && culero >= 0)
                        {

                            arribay(prueba.getColumna(), es, prueba.getColor(), color);
                            arribay(diego, es, prueba.getColor(), color);
                            arribay(puto, es, prueba.getColor(), color);
                            arribay(diego, prueba.getFila(), prueba.getColor(), color);
                            arribay(puto, prueba.getFila(), prueba.getColor(), color);
                            arribay(prueba.getColumna(), culero, prueba.getColor(), color);
                            arribay(puto, culero, prueba.getColor(), color);
                            arribay(diego, culero, prueba.getColor(), color);


                        }
                    }
                    verabajo(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verarriba(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verDer(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verIzq(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verabajoD(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verabajoI(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verarribaD(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    verarribaI(prueba.getColumna(), prueba.getFila(), prueba.getColor(),o);
                    if (pruebas >= 1 && ayuda >= 1)
                    {
                        contador3 = ayuda;
                        ayuda = 0;
                        pruebas = 0;
                        Cont = 0;
                        vacios.Clear();
                    }
                    else
                    {
                        contador3 = 0;
                        pruebas = 0;
                        vacios.Clear();
                    }


                }
            }


        }

        public bool verificarco(int x, int y, string color,int o)
        {

            bool p = false;
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    if ((( prueba.getColor().Equals(color) || Dinamico.colores1.Contains(prueba.getColor())==true) && (o==1 || o==3 || o==5 || o==7 || o==9)) || ((prueba.getColor().Equals(color) || Dinamico.colores2.Contains(prueba.getColor()) == true) && (o==0 || o==2 || o==4 || o==6 || o==8 || o==10 )))
                    {
                        p = false;
                        Cont++;
                        ayuda++;
                        encon++;
                        vacios.AddLast(prueba.getId());
                        break;

                    }
                    else if (prueba.getColor() == "vacio")
                    {
                        p = false;

                        l = 0;
                        if (contador3 != 0 || encon <= 1)
                        {
                            encon = 0;
                            auxiliar = 1;
                            contador3 = 0;
                        }


                        break;



                    }
                    else
                    {
                        p = true;
                        if (contador3 != 0 && (auxiliar == 1 || Cont == 1))
                        {
                            contador3 = 0;
                        }
                        else
                        {
                            contador3++;
                        }
                        break;

                        return p;
                    }
                }
            }

            return p;
        }

        public void verarriba(int x, int y, string color,int o)
        {
            int l = 0;
            contador3 = 0;
            auxiliar = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        for (int i = y - 1; i >= 1; i--)
                        {
                            verificarco(x, i, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;
                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;


                            }
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }
        public void verabajo(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        for (int i = prueba.getFila() + 1; i <= cantidad; i++)
                        {
                            verificarco(x, i, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;

                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;




                            }
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }
        public void verDer(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        for (int i = prueba.getColumna() + 1; i <= cantidad2; i++)
                        {
                            verificarco(i, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;
                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;




                            }
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }
        public void verIzq(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        for (int i = prueba.getColumna() - 1; i >= 1; i--)
                        {
                            verificarco(i, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;

                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;



                            }
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }

        public void verabajoD(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int po = 0;
            x = x + 1;
            y = y + 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        while (true)
                        {
                            if ((x > cantidad2 && y > cantidad) || (x < 1 && y < 1) || (x > cantidad2 && y < 1) || (x < 1 && y > cantidad))
                            {
                                break;
                            }
                            verificarco(x, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;

                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    po = 1;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;


                            }
                            if (ayuda != 0 && l != 0)
                            {
                                po = 1;
                                break;
                            }
                            x++;
                            y++;
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }
        public void verabajoI(int x, int y, string color, int o)
        {
            auxiliar = 0;
            int po = 0;
            x = x - 1;
            y = y + 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        while (true)
                        {
                            if ((x > cantidad2 && y > cantidad) || (x < 1 && y < 1) || (x > cantidad2 && y < 1) || (x < 1 && y > cantidad))
                            {
                                break;
                            }

                            verificarco(x, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;
                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    po = 1;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;


                            }
                            if (ayuda != 0 && l != 0)
                            {
                                po = 1;
                                break;
                            }
                            x--;
                            y++;
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }
        public void verarribaD(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int po = 0;
            x = x + 1;
            y = y - 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Botones prueba in tablero)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        while (true)
                        {
                            if ((x > cantidad2 && y > cantidad) || (x < 1 && y < 1) || (x > cantidad2 && y < 1) || (x < 1 && y > cantidad))
                            {
                                break;
                            }

                            verificarco(x, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;
                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    po = 1;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }
                                pruebas++;


                            }
                            if (ayuda != 0 && l != 0)
                            {
                                po = 1;
                                break;
                            }
                            x++;
                            y--;
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }

            }
        }
        public void verarribaI(int x, int y, string color,int o)
        {
            auxiliar = 0;
            int po = 0;
            x = x - 1;
            y = y - 1;
            int l = 0;
            if (ayuda == 0)
            {


                foreach (Botones prueba in tablero)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.getColumna() == x && prueba.getFila() == y)
                    {
                        while (true)
                        {
                            if ((x > cantidad2 && y > cantidad) || (x < 1 && y < 1) || (x > cantidad2 && y < 1) || (x < 1 && y > cantidad))
                            {
                                break;
                            }

                            verificarco(x, y, color,o);
                            if (contador3 != 0 && auxiliar != 1 && Cont >= 1)
                            {
                                l++;
                                Cont = 0;
                                break;

                            }
                            else
                            {
                                if (Cont == 1)
                                {
                                    Cont = 0;
                                    po = 1;
                                    break;
                                }
                                if (Cont == 0)
                                {
                                    auxiliar = 0;
                                }

                                pruebas++;


                            }
                            if (ayuda != 0 && l != 0)
                            {
                                po = 1;
                                break;
                            }
                            y--;
                            x--;
                        }
                    }
                }
                if (l == 0)
                {
                    ayuda = 0;
                }
            }
        }

        public void pruebadiego2(string id, int o,int p)
        {
            contador3 = 0;
            contador2 = 0;
            ayuda = 0;
            string c = "";
            foreach (Botones prueba in tablero)
            {
                if (prueba.getId().Equals(id))
                {

                    if (o == 1 && (int)ViewState["t"] == 1 && (int)ViewState["verifi"] != -1)
                    {
                        if (p == 2)
                        {
                            prueba.setColor("Violet");
                            c = "Violet";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 4)
                        {
                            prueba.setColor("White");
                            c = "White";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 6)
                        {
                            prueba.setColor("Black");
                            c = "Black";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 8)
                        {
                            prueba.setColor("LightBlue");
                            c = "LightBlue";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 10)
                        {
                            prueba.setColor("Gray");
                            c = "Gray";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        


                    }
                    if (o == 0 && (int)ViewState["t"] == 1 && (int)ViewState["verifi"] != 1)
                    {
                        if (p == 1)
                        {
                            prueba.setColor("Red");
                            c = "Red";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 3)
                        {
                            prueba.setColor("Yellow");
                            c = "Yellow";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 5)
                        {
                            prueba.setColor("Blue");
                            c = "Blue";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 7)
                        {
                            prueba.setColor("Orange");
                            c = "Orange";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }
                        else if (p == 9)
                        {
                            prueba.setColor("LightGreen");
                            c = "LightGreen";
                            ViewState["t"] = 0;
                            ViewState["verifi"] = 0;
                        }


                    }
                    if (c == "")
                    {
                        continue;
                    }
                    if (prueba.getColumna() == cantidad2)
                    {
                        arriba(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        abajo(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Der(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Izq(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Dabajo(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Iabajo(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Darriba(prueba.getColumna() - 1, prueba.getFila(), c, p);
                        Iarriba(prueba.getColumna() - 1, prueba.getFila(), c, p);
                    }
                    else if (prueba.getFila() == cantidad)
                    {
                        arriba(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        abajo(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Der(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Izq(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Dabajo(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Iabajo(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Darriba(prueba.getColumna(), prueba.getFila() - 1, c, p);
                        Iarriba(prueba.getColumna(), prueba.getFila() - 1, c, p);
                    }
                    else
                    {
                        arriba(prueba.getColumna(), prueba.getFila(), c, p);
                        abajo(prueba.getColumna(), prueba.getFila(), c, p);
                        Der(prueba.getColumna(), prueba.getFila(), c, p);
                        Izq(prueba.getColumna(), prueba.getFila(), c, p);
                        Dabajo(prueba.getColumna(), prueba.getFila(), c, p);
                        Iabajo(prueba.getColumna(), prueba.getFila(), c, p);
                        Darriba(prueba.getColumna(), prueba.getFila(), c, p);
                        Iarriba(prueba.getColumna(), prueba.getFila(), c, p);
                    }
                }
            }





        }
        public void arriba(int x, int y, string color,int o)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    for (int i = y - 1; i >= 1; i--)
                    {
                        if (verificarco(x, i, color,o) == true)
                        {
                            prueb.AddLast(fichacolor(x, i, color));

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                auxiliar = 0;

                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();
                            break;
                        }

                    }
                }
            }
            cambiar(color,x,y);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void abajo(int x, int y, string color,int o)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    for (int i = y + 1; i <= cantidad; i++)
                    {
                        if (verificarco(x, i, color,o) == true)
                        {
                            posiciones.AddLast(fichacolor(x, i, color));

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                auxiliar = 0;

                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();
                            break;
                        }

                    }
                }
            }
            cambiar(color,x,y);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }
        public void Der(int x, int y, string color,int o)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    for (int i = x + 1; i <= cantidad2; i++)
                    {
                        if (verificarco(i, y, color,o) == true)
                        {
                            prueb.AddLast(fichacolor(i, y, color));


                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                auxiliar = 0;

                            }

                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();
                            break;
                        }

                    }
                }
            }
            cambiar(color,x,y);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Izq(int x, int y, string color,int o)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    for (int i = x - 1; i >= 1; i--)
                    {
                        if (verificarco(i, y, color,o) == true)
                        {
                            prueb.AddLast(fichacolor(i, y, color));


                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                auxiliar = 0;

                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();
                            break;
                        }

                    }
                }
            }
            cambiar(color,x,y);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Dabajo(int x1, int y1, string color,int o)
        {
            int po = 0;
            int x = x1;
            int y = y1;
              
            foreach (Botones prueba in tablero)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    while (true)
                    {
                        if ((x >= cantidad2 && y >= cantidad) || (x < 1 && y < 1) || (x >= cantidad2 && y < 1) || (x < 1 && y >= cantidad))
                        {
                            break;
                        }

                        if (verificarco(x, y, color,o) == true)
                        {
                            prueb.AddLast(fichacolor(x, y, color));

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                prueb = new LinkedList<string>();
                                auxiliar = 0;
                                po = 1;
                                break;
                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                                if (prueb.Count != 0)
                                {
                                    po = 1;
                                    break;
                                }

                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();

                        }
                        x++;
                        y++;
                    }
                    //    for (int i = y - 1; i >= 1; i--)
                    //    {
                    //        Response.Write("<script>console.log('" + x.ToString() + i.ToString() + color + "')</script>");
                    //        if (verificarco(x, i, color) == true)
                    //        {
                    //            prueb.AddLast(fichacolor(x, i, color));

                    //        }
                    //        else
                    //        {

                    //            if (Cont == 1)
                    //            {
                    //                foreach (string pru in prueb)
                    //                {
                    //                    posiciones.AddLast(pru);
                    //                }
                    //            }
                    //            Cont = 0;
                    //            prueb = new LinkedList<string>();
                    //            break;
                    //        }

                    //    }
                }
            }
            cambiar(color,x1,y1);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Iabajo(int x1, int y1, string color,int o)
        {
            int po = 0;
            int x = x1;
            int y = y1;
            foreach (Botones prueba in tablero)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    while (true)
                    {
                        if ((x >= cantidad2 && y >= cantidad) || (x < 1 && y < 1) || (x >= cantidad2 && y < 1) || (x < 1 && y >= cantidad))
                        {
                            break;
                        }

                        if (verificarco(x, y, color,o) == true)
                        {
                            prueb.AddLast(fichacolor(x, y, color));

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                prueb = new LinkedList<string>();
                                auxiliar = 0;
                                po = 1;
                                break;
                            }

                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                                if (prueb.Count != 0)
                                {
                                    po = 1;
                                    break;
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();

                        }
                        x--;
                        y++;
                    }
                    //    for (int i = y - 1; i >= 1; i--)
                    //    {
                    //        Response.Write("<script>console.log('" + x.ToString() + i.ToString() + color + "')</script>");
                    //        if (verificarco(x, i, color) == true)
                    //        {
                    //            prueb.AddLast(fichacolor(x, i, color));

                    //        }
                    //        else
                    //        {

                    //            if (Cont == 1)
                    //            {
                    //                foreach (string pru in prueb)
                    //                {
                    //                    posiciones.AddLast(pru);
                    //                }
                    //            }
                    //            Cont = 0;
                    //            prueb = new LinkedList<string>();
                    //            break;
                    //        }

                    //    }
                }
            }
            cambiar(color,x1,y1);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Darriba(int x1, int y1, string color,int o)
        {
            int po = 0;
            int x = x1;
            int y = y1;
            foreach (Botones prueba in tablero)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    while (true)
                    {
                        if ((x >= cantidad2 && y >= cantidad) || (x < 1 && y < 1) || (x >= cantidad2 && y < 1) || (x < 1 && y >= cantidad))
                        {
                            break;
                        }

                        if (verificarco(x, y, color,o) == true)
                        {

                            if (fichacolor(x, y, color) != "vacio")
                            {
                                prueb.AddLast(fichacolor(x, y, color));
                            }
                            else
                            {
                                prueb = new LinkedList<string>();
                                prueb.Clear();
                                po = 1;
                                break;
                            }

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                auxiliar = 0;
                                po = 1;
                                break;
                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {

                                    posiciones.AddLast(pru);
                                }
                                if (prueb.Count != 0)
                                {
                                    po = 1;
                                    break;
                                }
                            }

                            Cont = 0;
                            prueb = new LinkedList<string>();

                        }
                        x++;
                        y--;
                    }
                    //    for (int i = y - 1; i >= 1; i--)
                    //    {
                    //        Response.Write("<script>console.log('" + x.ToString() + i.ToString() + color + "')</script>");
                    //        if (verificarco(x, i, color) == true)
                    //        {
                    //            prueb.AddLast(fichacolor(x, i, color));

                    //        }
                    //        else
                    //        {

                    //            if (Cont == 1)
                    //            {
                    //                foreach (string pru in prueb)
                    //                {
                    //                    posiciones.AddLast(pru);
                    //                }
                    //            }
                    //            Cont = 0;
                    //            prueb = new LinkedList<string>();
                    //            break;
                    //        }

                    //    }
                }
            }
            cambiar(color,x1,y1);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Iarriba(int x1, int y1, string color,int o)
        {
            int po = 0;
            int x = x1;
            int y = y1;
            foreach (Botones prueba in tablero)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    while (true)
                    {
                        if ((x >= cantidad2 && y >= cantidad) || (x < 1 && y < 1) || (x >= cantidad2 && y < 1) || (x < 1 && y >= cantidad))
                        {
                            break;
                        }

                        if (verificarco(x, y, color,o) == true)
                        {

                            prueb.AddLast(fichacolor(x, y, color));

                        }
                        else
                        {
                            if (auxiliar == 1)
                            {
                                prueb = new LinkedList<string>();
                                auxiliar = 0;
                                po = 1;
                                break;
                            }
                            if (Cont == 1)
                            {
                                foreach (string pru in prueb)
                                {
                                    posiciones.AddLast(pru);
                                }
                                if (prueb.Count != 0)
                                {
                                    po = 1;
                                    break;
                                }
                            }
                            Cont = 0;
                            prueb = new LinkedList<string>();

                        }
                        x--;
                        y--;
                    }
                    //    for (int i = y - 1; i >= 1; i--)
                    //    {
                    //        Response.Write("<script>console.log('" + x.ToString() + i.ToString() + color + "')</script>");
                    //        if (verificarco(x, i, color) == true)
                    //        {
                    //            prueb.AddLast(fichacolor(x, i, color));

                    //        }
                    //        else
                    //        {

                    //            if (Cont == 1)
                    //            {
                    //                foreach (string pru in prueb)
                    //                {
                    //                    posiciones.AddLast(pru);
                    //                }
                    //            }
                    //            Cont = 0;
                    //            prueb = new LinkedList<string>();
                    //            break;
                    //        }

                    //    }
                }
            }
            cambiar(color,x1,y1);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public string fichacolor(int x, int y, string color)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    if (prueba.getColor() == "vacio")
                    {
                        return "vacio";
                    }
                    return prueba.getId();
                }
            }
            return "";
        }

        private void Ficha_click(object sender, EventArgs e)
        {
            Botones Seleccionado = (Botones)sender;
            if (colo == (Dinamico.colores1.Count + Dinamico.colores2.Count)+1)
            {
                colo = 1;
            }else if (validar2 == 1)
            {
                colo = 1;
                validar2 = 2;
            }

            pruebadiego(Seleccionado.getId(), Color2(), colo);
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    if (colo == 1)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Red;
                    }
                    else if (colo == 3)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (colo == 5)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Blue;
                    }
                    else if (colo == 7)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Orange;
                    }
                    else if (colo == 9)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.LightGreen;
                    }

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    if (colo == 2)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Violet;
                    }
                    else if (colo == 4)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.White;
                    }
                    else if (colo == 6)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Black;
                    }
                    else if (colo == 8)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else if (colo == 10)
                    {
                        Seleccionado.BackColor = System.Drawing.Color.Gray;
                    }
                    

                }
            }
            pruebadiego2(Seleccionado.getId(), (int)ViewState["turno"],colo);
            mov();
            

        }

        public int turnos()
        {
            if (colo == (Dinamico.colores1.Count + Dinamico.colores2.Count))
            {
                colo = 0;
            }
            if (colo == 0)
            {
                colo = 1;
            }else if (colo == 1)
            {
                colo = 2;
            }else if (colo == 2)
            {
                colo = 3;
            }
            else if (colo == 3)
            {
                colo = 4;
            }
            else if (colo == 4)
            {
                colo = 5;
            }
            else if (colo == 5)
            {
                colo = 6;
            }
            else if (colo == 6)
            {
                colo = 7;
            }
            else if (colo == 7)
            {
                colo = 8;
            }
            else if (colo == 8)
            {
                colo = 9;
            }
            else if (colo == 9)
            {
                colo = 10;
            }
            else if (colo == 10)
            {
                colo = 1;
            }
            return colo;
        }

        public int Color()
        {
            int re = 1;

            if (ViewState["click"] != null)
            {

                if ((int)ViewState["click"] == 1)
                {
                    ViewState["click"] = 0;
                    re = (int)ViewState["click"];


                }
                else if ((int)ViewState["click"] == 0)
                {
                    ViewState["click"] = 1;
                    re = (int)ViewState["click"];



                }
                return re;


            }
            else
            {
                ViewState["click"] = 1;
                re = (int)ViewState["click"];
                return re;
            }

        }

        public int Color2()
        {


            if (ViewState["click2"] != null)
            {

                if ((int)ViewState["click2"] == 1 && (int)ViewState["bandera"] != 1)
                {
                    ViewState["click2"] = 0;
                    ViewState["re"] = (int)ViewState["click2"];


                }
                else if ((int)ViewState["click2"] == 0 && (int)ViewState["bandera"] != 0)
                {
                    ViewState["click2"] = 1;
                    ViewState["re"] = (int)ViewState["click2"];

                }
                return (int)ViewState["re"];


            }
            else
            {
                ViewState["click2"] = 1;
                ViewState["re"] = 1;
                ViewState["bandera"] = 1;
                return (int)ViewState["re"];

            }

        }

        public void cambiar(string color ,int x, int y)
        {
            if (x == cantidad2)
            {
                x = x - 1;
            }
            if (y == cantidad)
            {
                y = y - 1;
            }
            if (((color == "Red") || (color == "Yellow") || (color == "Blue") || (color == "Orange") || (color == "LightGreen")) && vacios.Count==0 )
            {
                ViewState["turno"] = 1;
            }
            else if (((color == "Violet") || (color == "White") || (color == "Black") || (color == "LightBlue") || (color == "Gray")) && vacios.Count == 0)
            {
                ViewState["turno"] = 0;
            }
            foreach (string o in posiciones)
            {

                Botones c1 = bus(o);

                foreach (string vac in vacios)
                {
                    Botones c2 = tablero[y, x];

                    if ((color == "Red") || (color == "Yellow") || (color == "Blue") || (color == "Orange") || (color == "LightGreen"))
                    {

                        if (color=="Red")
                        {
                            colo = 2;
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.Red;
                            colores(cantidad, cantidad2);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;
                                                       
                        }
                        else if (color == "Yellow")
                        {
                            colo =4;
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.Yellow;
                            colores(cantidad, cantidad2);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;

                        }
                        else if (color == "Blue")
                        {
                            colo = 6;
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.Blue;
                            colores(cantidad, cantidad2);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;

                        }
                        else if (color == "Orange")
                        {
                            colo = 8;
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.Orange;
                            colores(cantidad, cantidad2);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;

                        } else if (color == "LightGreen")
                        {
                            colo = 10;
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.LightGreen;
                            colores(cantidad, cantidad2);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;

                        }
                    }
                    else if ((color == "Violet") || (color == "White") || (color == "Black") || (color == "LightBlue") || (color == "Gray"))
                    {

                        if (color == "Violet")
                        {
                            colo = 3;
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.Violet;
                            colores(cantidad, cantidad2);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                        else if (color == "White")
                        {
                            colo = 5;
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.White;
                            colores(cantidad, cantidad2);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                        else if (color == "Black")
                        {
                            colo = 7;
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.Black;
                            colores(cantidad, cantidad2);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                        else if (color == "LightBlue")
                        {
                            colo = 9;
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.LightBlue;
                            colores(cantidad, cantidad2);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                        else if (color == "Gray")
                        {
                            colo = 1;
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.Gray;
                            colores(cantidad, cantidad2);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                    }
                }





            }
           
        }

        public Botones bus(string id)
        {
            Botones c;
            for (int i = 0; i < cantidad; i++)
            {
                for (int j = 0; j < cantidad2; j++)
                {
                    if (tablero[i, j].getId().Equals(id))
                    {
                        c = tablero[i, j];
                        return c;
                        
                    }
                }
            }
            return null;
           
        }
        public string buscar(string color,int o)
        {
            string casillas = "Posiciones posibles:";
            int y;
            int x;
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColor().Equals("vacio"))
                {
                    if (colorcerca(prueba.getColumna(), prueba.getFila() + 1, color,o) == true)
                    {
                        y = prueba.getFila() + 1;
                        while (true)
                        {

                            if (verificarco2(prueba.getColumna(), y, color,o) == false && y >= 1 && y <= cantidad)
                            {

                                Response.Write("<script>console.log('aqui esta tu concha abajo" + prueba.getId() + prueba.getColumna() + " " + y + prueba.getColor() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (y >= cantidad)
                            {
                                break;
                            }
                            y++;

                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() + 1, prueba.getFila(), color,o) == true)
                    {
                        x = prueba.getColumna() + 1;
                        while (true)
                        {

                            if (verificarco2(x, prueba.getFila(), color,o) == false && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha derecha" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x >= cantidad2)
                            {
                                break;
                            }
                            x++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() - 1, prueba.getFila(), color,o) == true)
                    {
                        x = prueba.getColumna() - 1;
                        while (true)
                        {

                            if (verificarco2(x, prueba.getFila(), color,o) == false && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha izquierda" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x <= 1)
                            {
                                break;
                            }
                            x--;
                        }

                    }
                    poto = 0;

                    if (colorcerca(prueba.getColumna(), prueba.getFila() - 1, color,o) == true)
                    {
                        y = prueba.getFila() - 1;
                        while (true)
                        {

                            if (verificarco2(prueba.getColumna(), y, color,o) == false && y >= 1 && y <= cantidad)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha arriba" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (y <= 1)
                            {
                                break;
                            }
                            y--;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() + 1, prueba.getFila() + 1, color,o) == true)
                    {
                        x = prueba.getColumna() + 1;
                        y = prueba.getFila() + 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color,o) == false && y >= 1 && y <= cantidad && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x >= cantidad2 || y >= cantidad || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x++;
                            y++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() - 1, prueba.getFila() + 1, color,o) == true)
                    {
                        x = prueba.getColumna() - 1;
                        y = prueba.getFila() + 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color,o) == false && y >= 1 && y <= cantidad && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x >= cantidad2 || y >= cantidad || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x--;
                            y++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() - 1, prueba.getFila() - 1, color,o) == true)
                    {
                        x = prueba.getColumna() - 1;
                        y = prueba.getFila() - 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color,o) == false && y >= 1 && y <= cantidad && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x >= cantidad2 || y >= cantidad || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x--;
                            y--;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.getColumna() + 1, prueba.getFila() - 1, color,o) == true)
                    {
                        x = prueba.getColumna() + 1;
                        y = prueba.getFila() - 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color,o) == false && y >= 1 && y <= cantidad && x >= 1 && x <= cantidad2)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.getId() + "')</script>");
                                casillas += " " + prueba.getId();
                                maquina.AddLast(prueba.getId());
                                posibles.AddLast(prueba.getId());
                                break;
                            }
                            if (x >= cantidad2 || y >= cantidad || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            y--;
                            x++;
                        }

                    }
                    poto = 0;
                }
            }
            return casillas;

        }
        public bool colorcerca(int x, int y, string color,int o)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {
                    if ((prueba.getColor() != color && prueba.getColor() != "vacio" && (Dinamico.colores1.Contains(prueba.getColor()))==false && o==0) || (prueba.getColor() != color && prueba.getColor() != "vacio" && (Dinamico.colores2.Contains(prueba.getColor())) == false && o == 1))
                    {
                        Response.Write("<script>console.log('asdhaksdhaks" + x.ToString() + y.ToString() + color + "')</script>");
                        return true;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return false;
        }
        public bool verificarco2(int x, int y, string color,int o)
        {

            bool p = false;
            foreach (Botones prueba in tablero)
            {
                if (prueba.getColumna() == x && prueba.getFila() == y)
                {

                    if ((Dinamico.colores1.Contains(color)==true && prueba.getColor() != "vacio" && poto >= 1 && o==0) ||(Dinamico.colores2.Contains(color) == true && prueba.getColor() != "vacio" && poto >= 1 && o==1))
                    {

                        Response.Write("<script>console.log('aqui esta tu concha abajo prueba: " + "id: " + prueba.getId() + "pos x: " + prueba.getColumna() + "posy: " + y + prueba.getColor() + "')</script>");
                        p = false;
                        Cont++;
                        poto = 0;


                        return p;
                    }
                    else if ((Dinamico.colores1.Contains(prueba.getColor())==false && o==0) || (Dinamico.colores2.Contains(prueba.getColor())==false && o==1))
                    {
                        p = true;
                        poto++;
                        return p;
                    }



                }
            }

            return p;
        }
        public void encontrar(string nombre, string modalidad, int G, int P, int E)
        {
            string sql = string.Empty;
            string usu = nombre;
            string sql2 = string.Empty;
            string sql3 = string.Empty;
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();

            sql = string.Format("Select nombres,apellidos from info where usuario='{0}'", usu);
            sql3 = string.Format("Select nombres from info where usuario='{0}'", usu);
            sql2 = string.Format("Select apellidos from info where usuario='{0}'", usu);

            SqlCommand coma = new SqlCommand(sql, sqlcon);
            SqlCommand coma3 = new SqlCommand(sql3, sqlcon);
            SqlCommand cm2 = new SqlCommand(sql2, sqlcon);

            SqlDataReader reg = null;

            reg = coma.ExecuteReader();

            if (reg.Read() == true)
            {

                reg.Close();
                nombres = coma3.ExecuteScalar().ToString();
                apellido = cm2.ExecuteScalar().ToString();

                if (WebForm1.num == 2)
                {
                    sql2 = string.Format("Select ganadas,perdidas,empatadas from Reportes where usuario='{0} and modalidad={1}'", usu, "JCM");
                }
                else
                {
                    sql2 = string.Format("Select ganadas,perdidas,empatadas from Reportes where usuario='{0} and modalidad={1}'", usu, "JCJ");
                }
                sqlcon.Close();
            }
            if (DTbuscar(nombre, G, P, E) == true)
            {

                SqlDataAdapter instertar = new SqlDataAdapter("insert into Reportes(nombre,apellido,usuario,modalidad,ganadas,perdidas,empatadas) values('" + nombres + "','" + apellido + "','" + usu + "','" + modalidad + "','" + ganadas + "','" + perdidas + "','" + empatadas + "')", sqlcon);
                DataTable ins2 = new DataTable();
                instertar.Fill(ins2);
                sqlcon.Close();
            }
            else
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    SqlDataAdapter instertar = new SqlDataAdapter("insert into Reportes(nombre,apellido,usuario,modalidad,ganadas,perdidas,empatadas) values('" + nombres + "','" + apellido + "','" + usu + "','" + modalidad + "','" + G + "','" + P + "','" + E + "')", sqlcon);
                    DataTable ins = new DataTable();
                    instertar.Fill(ins);
                }

                sqlcon.Close();
            }

        }
        public bool DTbuscar(string nombre, int G, int P, int E)
        {
            string sql = string.Empty;
            string usu = nombre;
            string sql2 = string.Empty;



            string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";
            SqlConnection sqlcon = new SqlConnection(connectionString);
            sqlcon.Open();
            SqlDataReader reg2 = null;
            DataTable dt2 = new DataTable();
            if (WebForm1.num == 2)
            {
                sql2 = string.Format("Select ganadas,perdidas,empatadas from Reportes where usuario='{0} and modalidad={1}'", usu, "JCM");
            }
            else
            {
                sql2 = string.Format("Select ganadas,perdidas,empatadas from Reportes where usuario='{0}' and modalidad='{1}'", usu, "JCJ");
            }
            SqlCommand coma2 = new SqlCommand(sql2, sqlcon);


            SqlDataAdapter adap2 = new SqlDataAdapter(coma2);
            adap2.Fill(dt2);
            reg2 = coma2.ExecuteReader();


            if (reg2.Read() == true)
            {


                DataRow row2 = dt2.Rows[0];
                if (G >= 1)
                {
                    ganadas = Convert.ToInt32(row2["ganadas"]) + 1;
                    perdidas = Convert.ToInt32(row2["perdidas"]);
                    empatadas = Convert.ToInt32(row2["empatadas"]);
                }
                else if (P >= 1)
                {
                    ganadas = Convert.ToInt32(row2["ganadas"]);
                    perdidas = Convert.ToInt32(row2["perdidas"]) + 1;
                    empatadas = Convert.ToInt32(row2["empatadas"]);
                }
                else
                {
                    ganadas = Convert.ToInt32(row2["ganadas"]);
                    perdidas = Convert.ToInt32(row2["perdidas"]);
                    empatadas = Convert.ToInt32(row2["empatadas"]) + 1;
                }
                return true;
            }
            sqlcon.Close();
            return false;
        }

        public void cargar2(string nombre)
        {
            string cf = "";
            string columna = "";
            string fila = "";
            string ficha = "";
            int val = 0;
            int filas = 0;
            int columnas = 0;

            using (XmlTextReader xmlReader = new XmlTextReader(@"C:\\Users\\DELL\\Desktop\\ConexionSQL\\" + nombre ))
            {
                while (xmlReader.Read())
                {
                    if ((xmlReader.NodeType == XmlNodeType.Element) && (xmlReader.Name == "ficha"))
                    {
                        val += 1;
                    }
                }
            }


            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"C:\\Users\\DELL\\Desktop\\ConexionSQL\\" + nombre);
            XmlNodeList inicio = xmlDoc.GetElementsByTagName("partida");
            foreach (XmlElement x in inicio) 
            {
                XmlNodeList f = ((XmlElement)x).GetElementsByTagName("filas");
                cantidadC = Int32.Parse(f[0].InnerText);
            }
            foreach (XmlElement y in inicio)
            {
                XmlNodeList c = ((XmlElement)y).GetElementsByTagName("columnas");
                cantidad2C = Int32.Parse(c[0].InnerText);
            }
            XmlNodeList J1 = xmlDoc.GetElementsByTagName("Jugador1");
            XmlNodeList co1 = ((XmlElement)J1[0]).GetElementsByTagName("color");
            foreach (XmlElement cor in co1)
            {
                Dinamico.colores1.Add(cor.InnerText);
            }
            XmlNodeList J2 = xmlDoc.GetElementsByTagName("Jugador2");
            XmlNodeList co2 = ((XmlElement)J2[0]).GetElementsByTagName("color");
            foreach (XmlElement cor in co2)
            {
                Dinamico.colores2.Add(cor.InnerText);
            }
            Pruebas(cantidadC, cantidad2C);

            XmlNodeList tablero = xmlDoc.GetElementsByTagName("tablero");
            foreach (XmlElement fichas in tablero)
            {
                XmlNodeList ficha2 = ((XmlElement)fichas).GetElementsByTagName("ficha");
                foreach (XmlElement noficha in ficha2)
                {
                    XmlNodeList co = noficha.GetElementsByTagName("color");
                    XmlNodeList colu = noficha.GetElementsByTagName("columna");
                    XmlNodeList fi = noficha.GetElementsByTagName("fila");
                    columna = colu[0].InnerText.ToLower();
                    string l = columna + fi[0].InnerText;
                    cf = co[0].InnerText;
                    poner(l, cf);

                }
            }
            colo = 1;
            validar2 = 1;
           

           


        }

        public void poner(string id, string color)
        {
            foreach (Botones prueba in tablero)
            {
                if (prueba.getId().Equals(id))
                {
                    if (color == "rojo")
                    {
                        prueba.BackColor = System.Drawing.Color.Red;
                    }
                    else if (color == "amarillo")
                    {
                        prueba.BackColor = System.Drawing.Color.Yellow;
                    }
                    else if (color == "azul")
                    {
                        prueba.BackColor = System.Drawing.Color.Blue;
                    }
                    else if (color == "anaranjado")
                    {
                        prueba.BackColor = System.Drawing.Color.Orange;
                    }
                    else if (color == "verde")
                    {
                        prueba.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else if (color == "violeta")
                    {
                        prueba.BackColor = System.Drawing.Color.Violet;
                    }
                    else if (color == "blanco")
                    {
                        prueba.BackColor = System.Drawing.Color.White;
                    }
                    else if (color == "negro")
                    {
                        prueba.BackColor = System.Drawing.Color.Black;
                    }
                    else if (color == "celeste")
                    {
                        prueba.BackColor = System.Drawing.Color.LightBlue;
                    }
                    else if (color == "gris")
                    {
                        prueba.BackColor = System.Drawing.Color.Gray;
                    }
                }
            }
        }



        public class Botones : System.Web.UI.WebControls.Button
        {
            private int columna;
            private int fila;
            private string id;
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

            public void setId(string id) {
                this.id = id;
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

            public string getId()
            {
                return id;
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
    }
}

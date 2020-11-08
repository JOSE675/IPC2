using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
using IPC2;
namespace IPC2
{
    public partial class WebForm3 : System.Web.UI.Page
    {

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
        

        LinkedList<string> vacios = new LinkedList<string>();
        LinkedList<string> prueb = new LinkedList<string>();
        LinkedList<Ficha> fichita = new LinkedList<Ficha>();
        LinkedList<string> posiciones = new LinkedList<string>();
        LinkedList<string> maquina = new LinkedList<string>();
        LinkedList<string> posibles = new LinkedList<string>();
        bool quiza = false;
        public int contador = 0;
        public int contador2 = 0;
        public int contador3 = 0;
        int ascii = 97;

        protected void Page_Load(object sender, EventArgs e)
        {
            ViewState["vali"] = ViewState["vali"];
            contador++;

            if (ViewState["vali"] == null)
            {
                
                d4.BackColor = System.Drawing.Color.White;
                e4.BackColor = System.Drawing.Color.Black;
                d5.BackColor = System.Drawing.Color.Black;
                e5.BackColor = System.Drawing.Color.White;
                ViewState["vali"] = 1;
                ViewState["turno"] = 0;
                ViewState["verifi"] = -1;
                ViewState["t"] = 0;
                ViewState["t2"] = 0;
                ViewState["blancas"] = 0;
                ViewState["negras"] = 0;
                nombre = Login.nombre;
                
            }
            if (WebForm1.num == 1)
            {
                cargar();
                verdes();
                WebForm1.num = 0;
                mov();
            }
            guardarfichas("", (int)ViewState["turno"]);

            if ((int)ViewState["t2"] == 0)
            {
                mov();
                ViewState["t2"] = 1;
            }
            



        }

        public void guardarfichas(string q, int p)
        {
            if (contador == 1)
            {
                ViewState["bandera"] = ViewState["bandera"];
                int x = 0;
                int y = 0;
                char a = 'a';
                string ide = "";
                string color = "";
                if (q == "")
                {
                    fichita = new LinkedList<Ficha>();
                    ascii = 97;
                    for (int i = 1; i <= 8; i++)
                    {

                        for (int j = 1; j <= 8; j++)
                        {
                            ide = a + j.ToString();

                            color = colores(ide);
                            guardarID(i, j, verificarcolor(ide), ide, color);

                        }

                        a = (char)(ascii + 1);
                        ascii++;
                    }
                }
                else
                {
                    fichita = new LinkedList<Ficha>();
                    ascii = 97;
                    for (int i = 1; i <= 8; i++)
                    {

                        for (int j = 1; j <= 8; j++)
                        {
                            ide = a + j.ToString();

                            color = colores(ide);
                            if (ide.Equals(q) && p == 1)
                            {
                                guardarID(i, j, true, ide, "blanco");
                            }
                            else if (ide.Equals(q) && p == 0)
                            {
                                guardarID(i, j, true, ide, "negro");
                            }
                            else
                            {
                                guardarID(i, j, verificarcolor(ide), ide, color);
                            }
                        }


                        if (ascii <= 104)
                        {
                            a = (char)(ascii + 1);
                            ascii++;
                        }
                    }


                }
            }
        }
        public void mov()
        {

            if ((int)ViewState["turno"] == 0)
            {
                string co = buscar("blanco");
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
                    fin++;
                }
            }
            else
            {
                string co = buscar("negro");
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
                    fin++;
                }
            }
            if (fin == 2)
            {
                int b = 0;
                int n = 0;
                int v = 0;
                foreach (Ficha prueba in fichita)
                {
                    if (prueba.Getcolor() == "blanco")
                    {
                        b++;
                    }
                    else if (prueba.Getcolor() == "negro")
                    {
                        n++;
                    }
                    else
                    {
                        v++;
                    }
                }
                if (WebForm1.reve == 1)
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
                    }
                    else if(b<n)
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
                    }
                    else if(b<n)
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
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
                        Response.Write("<script>console.log('" + "Partida terminada! blancas: " + b + " negras: " + n + "')</script>");
                    }
                    
                }
            }
            if (fin == 1)
            {
                mov();
            }
        }
        public void guardarID(int x, int y, bool ocupado, string id, string color)
        {
            fichita.AddLast(new Ficha(x, y, ocupado, id, color));
        }

        public string colores(string id)
        {

            string colorsito = "";
            Button c1 = FindControl(id) as Button;
            if (c1 != null)
            {
                if (c1.BackColor.Name == "White")
                {
                    colorsito = "blanco";
                }
                else if (c1.BackColor.Name == "Black")
                {
                    colorsito = "negro";
                }
                else if (c1.BackColor.Name == "Gray")
                {
                    colorsito = "vacio";
                    c1.BackColor = System.Drawing.Color.ForestGreen;
                }

                else
                {
                    colorsito = "vacio";
                }


            }

            return colorsito;
        }

        private void arribay(int x, int y, string color, int p)
        {


            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y && prueba.Getcolor() != color && prueba.Getocupado() == true)
                {
                    if (prueba.Getcolor().Equals("blanco") && p == 0)
                    {

                        contador2++;

                    }
                    else if (prueba.Getcolor().Equals("negro") && p == 1)
                    {
                        contador2++;
                    }
                    else
                    {
                        contador2 = 0;

                    }

                }





            }

        }

        public bool verificarcolor(string id)
        {
            Button c1 = FindControl(id) as Button;
            bool ocu;
            if (c1.BackColor.Name == "White" && c1 != null)
            {
                ocu = true;
            }
            else if (c1.BackColor.Name == "Black" && c1 != null)
            {
                ocu = true;
            }else if (c1.BackColor.Name=="Gray" && c1 != null)
            {
                ocu = false;
            }

            else
            {
                ocu = false;
            }
            return ocu;
        }

        public void pruebadiego(string id, int o)
        {
            int diego = 1;
            int es = 1;
            int puto = 1;
            int culero = 1;
            contador2 = 0;

            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getid().Equals(id))
                {

                    if (o == 1) { prueba.Setcolor("blanco"); }
                    if (o == 0) { prueba.Setcolor("negro"); }
                    diego = prueba.Getx() + 1;
                    es = prueba.Gety() + 1;
                    puto = prueba.Getx() - 1;
                    culero = prueba.Gety() - 1;
                    if (diego <= 9 && es <= 9 && puto >= 0 && culero >= 0)
                    {

                        arribay(prueba.Getx(), es, prueba.Getcolor(), o);
                        arribay(diego, es, prueba.Getcolor(), o);
                        arribay(puto, es, prueba.Getcolor(), o);
                        arribay(diego, prueba.Gety(), prueba.Getcolor(), o);
                        arribay(puto, prueba.Gety(), prueba.Getcolor(), o);
                        arribay(prueba.Getx(), culero, prueba.Getcolor(), o);
                        arribay(puto, culero, prueba.Getcolor(), o);
                        arribay(diego, culero, prueba.Getcolor(), o);


                    }
                    verabajo(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verarriba(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verDer(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verIzq(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verabajoD(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verabajoI(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verarribaD(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
                    verarribaI(prueba.Getx(), prueba.Gety(), prueba.Getcolor());
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
        public void verarriba(int x, int y, string color)
        {
            int l = 0;
            contador3 = 0;
            auxiliar = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        for (int i = y - 1; i >= 1; i--)
                        {
                            verificarco(x, i, color);
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
        public void verabajo(int x, int y, string color)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        for (int i = y + 1; i <= 8; i++)
                        {
                            verificarco(x, i, color);
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
        public void verDer(int x, int y, string color)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        for (int i = x + 1; i <= 8; i++)
                        {
                            verificarco(i, y, color);
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
        public void verIzq(int x, int y, string color)
        {
            auxiliar = 0;
            int l = 0;
            contador3 = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        for (int i = x - 1; i >= 1; i--)
                        {
                            verificarco(i, y, color);
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
        public void verabajoD(int x, int y, string color)
        {
            auxiliar = 0;
            int po = 0;
            x = x + 1;
            y = y + 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        while (true)
                        {
                            if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                            {
                                break;
                            }
                            verificarco(x, y, color);
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
        public void verabajoI(int x, int y, string color)
        {
            auxiliar = 0;
            int po = 0;
            x = x - 1;
            y = y + 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        while (true)
                        {
                            if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                            {
                                break;
                            }

                            verificarco(x, y, color);
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
        public void verarribaD(int x, int y, string color)
        {
            auxiliar = 0;
            int po = 0;
            x = x + 1;
            y = y - 1;
            int l = 0;
            if (ayuda == 0)
            {
                foreach (Ficha prueba in fichita)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        while (true)
                        {
                            if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                            {
                                break;
                            }

                            verificarco(x, y, color);
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
        public void verarribaI(int x, int y, string color)
        {
            auxiliar = 0;
            int po = 0;
            x = x - 1;
            y = y - 1;
            int l = 0;
            if (ayuda == 0)
            {


                foreach (Ficha prueba in fichita)
                {
                    if (po == 1)
                    {
                        po = 0;
                        break;
                    }
                    if (prueba.Getx() == x && prueba.Gety() == y)
                    {
                        while (true)
                        {
                            if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                            {
                                break;
                            }

                            verificarco(x, y, color);
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




        public void pruebadiego2(string id, int o)
        {
            contador3 = 0;
            contador2 = 0;
            ayuda = 0;
            string c = "";
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getid().Equals(id))
                {

                    if (o == 1 && (int)ViewState["t"] == 1 && (int)ViewState["verifi"] != -1)
                    {
                        prueba.Setcolor("blanco");
                        c = "negro";
                        ViewState["t"] = 0;
                        ViewState["verifi"] = 0;

                    }
                    if (o == 0 && (int)ViewState["t"] == 1 && (int)ViewState["verifi"] != 1)
                    {
                        prueba.Setcolor("negro");
                        c = "blanco";
                        ViewState["t"] = 0;
                        ViewState["verifi"] = 0;

                    }
                    if (c == "")
                    {
                        continue;
                    }
                    arriba(prueba.Getx(), prueba.Gety(), c);
                    abajo(prueba.Getx(), prueba.Gety(), c);
                    Der(prueba.Getx(), prueba.Gety(), c);
                    Izq(prueba.Getx(), prueba.Gety(), c);
                    Dabajo(prueba.Getx(), prueba.Gety(), c);
                    Iabajo(prueba.Getx(), prueba.Gety(), c);
                    Darriba(prueba.Getx(), prueba.Gety(), c);
                    Iarriba(prueba.Getx(), prueba.Gety(), c);
                }
            }





        }
        public void arriba(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    for (int i = y - 1; i >= 1; i--)
                    {
                        if (verificarco(x, i, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void abajo(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    for (int i = y + 1; i <= 8; i++)
                    {
                        if (verificarco(x, i, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }
        public void Der(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    for (int i = x + 1; i <= 8; i++)
                    {
                        if (verificarco(i, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Izq(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    for (int i = x - 1; i >= 1; i--)
                    {
                        if (verificarco(i, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Dabajo(int x, int y, string color)
        {
            int po = 0;
            foreach (Ficha prueba in fichita)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    while (true)
                    {
                        if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                        {
                            break;
                        }

                        if (verificarco(x, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Iabajo(int x, int y, string color)
        {
            int po = 0;
            foreach (Ficha prueba in fichita)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    while (true)
                    {
                        if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                        {
                            break;
                        }

                        if (verificarco(x, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Darriba(int x, int y, string color)
        {
            int po = 0;
            foreach (Ficha prueba in fichita)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    while (true)
                    {
                        if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                        {
                            break;
                        }

                        if (verificarco(x, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public void Iarriba(int x, int y, string color)
        {
            int po = 0;
            foreach (Ficha prueba in fichita)
            {
                if (po == 1)
                {
                    po = 0;
                    break;
                }
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    while (true)
                    {
                        if ((x > 8 && y > 8) || (x < 1 && y < 1) || (x > 8 && y < 1) || (x < 1 && y > 8))
                        {
                            break;
                        }

                        if (verificarco(x, y, color) == true)
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
            cambiar(color);
            vacios = new LinkedList<string>();
            posiciones = new LinkedList<string>();
            prueb = new LinkedList<string>();

        }

        public string buscar(string color)
        {
            string casillas = "Posiciones posibles:";
            int y;
            int x;
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getcolor().Equals("vacio"))
                {
                    if (colorcerca(prueba.Getx(), prueba.Gety() + 1, color) == true)
                    {
                        y = prueba.Gety() + 1;
                        while (true)
                        {

                            if (verificarco2(prueba.Getx(), y, color) == false && y >= 1 && y <= 8)
                            {

                                Response.Write("<script>console.log('aqui esta tu concha abajo" + prueba.Getid() + prueba.Getx() + " " + y + prueba.Getcolor() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (y >= 8)
                            {
                                break;
                            }
                            y++;

                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.Getx() + 1, prueba.Gety(), color) == true)
                    {
                        x = prueba.Getx() + 1;
                        while (true)
                        {

                            if (verificarco2(x, prueba.Gety(), color) == false && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha derecha" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (x >= 8)
                            {
                                break;
                            }
                            x++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.Getx() - 1, prueba.Gety(), color) == true)
                    {
                        x = prueba.Getx() - 1;
                        while (true)
                        {

                            if (verificarco2(x, prueba.Gety(), color) == false && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha izquierda" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
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

                    if (colorcerca(prueba.Getx(), prueba.Gety() - 1, color) == true)
                    {
                        y = prueba.Gety() - 1;
                        while (true)
                        {

                            if (verificarco2(prueba.Getx(), y, color) == false && y >= 1 && y <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha arriba" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
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
                    if (colorcerca(prueba.Getx() + 1, prueba.Gety() + 1, color) == true)
                    {
                        x = prueba.Getx() + 1;
                        y = prueba.Gety() + 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color) == false && y >= 1 && y <= 8 && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (x >= 8 || y >= 8 || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x++;
                            y++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.Getx() - 1, prueba.Gety() + 1, color) == true)
                    {
                        x = prueba.Getx() - 1;
                        y = prueba.Gety() + 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color) == false && y >= 1 && y <= 8 && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (x >= 8 || y >= 8 || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x--;
                            y++;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.Getx() - 1, prueba.Gety() - 1, color) == true)
                    {
                        x = prueba.Getx() - 1;
                        y = prueba.Gety() - 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color) == false && y >= 1 && y <= 8 && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (x >= 8 || y >= 8 || x <= 1 || y <= 1)
                            {
                                break;
                            }
                            x--;
                            y--;
                        }

                    }
                    poto = 0;
                    if (colorcerca(prueba.Getx() + 1, prueba.Gety() - 1, color) == true)
                    {
                        x = prueba.Getx() + 1;
                        y = prueba.Gety() - 1;
                        while (true)
                        {
                            if (verificarco2(x, y, color) == false && y >= 1 && y <= 8 && x >= 1 && x <= 8)
                            {
                                Response.Write("<script>console.log('aqui esta tu concha" + prueba.Getid() + "')</script>");
                                casillas += " " + prueba.Getid();
                                maquina.AddLast(prueba.Getid());
                                posibles.AddLast(prueba.Getid());
                                break;
                            }
                            if (x >= 8 || y >= 8 || x <= 1 || y <= 1)
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

        public bool colorcerca(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    if (prueba.Getcolor() != color && prueba.Getcolor() != "vacio")
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

        public bool verificarco(int x, int y, string color)
        {

            bool p = false;
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    if (prueba.Getcolor().Equals(color))
                    {
                        p = false;
                        Cont++;
                        ayuda++;
                        encon++;
                        vacios.AddLast(prueba.Getid());
                        break;

                    }
                    else if (prueba.Getcolor() == "vacio")
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

        public bool verificarco2(int x, int y, string color)
        {

            bool p = false;
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {

                    if (color.Equals(prueba.Getcolor()) && prueba.Getcolor() != "vacio" && poto >= 1)
                    {

                        Response.Write("<script>console.log('aqui esta tu concha abajo prueba: " + "id: " + prueba.Getid() + "pos x: " + prueba.Getx() + "posy: " + y + prueba.Getcolor() + "')</script>");
                        p = false;
                        Cont++;
                        poto = 0;


                        return p;
                    }
                    else if (color != prueba.Getcolor())
                    {
                        p = true;
                        poto++;
                        return p;
                    }



                }
            }

            return p;
        }

        public string fichacolor(int x, int y, string color)
        {
            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y)
                {
                    if (prueba.Getcolor() == "vacio")
                    {
                        return "vacio";
                    }
                    return prueba.Getid();
                }
            }
            return "";
        }

        public void cambiar(string color)
        {
            if (color == "blanco" && vacios.Count == 0)
            {
                ViewState["turno"] = 1;
            }
            else if (color == "negro" && vacios.Count == 0)
            {
                ViewState["turno"] = 0;
            }
            foreach (string o in posiciones)
            {

                Button c1 = FindControl(o) as Button;

                foreach (string vac in vacios)
                {
                    Button c2 = FindControl(vac) as Button;

                    if (color == "blanco")
                    {

                        if (c2.BackColor.Name == "White")
                        {
                            ViewState["turno"] = 1;
                            c1.BackColor = System.Drawing.Color.White;
                            guardarfichas(o, 1);
                            ViewState["blancas"] = (int)ViewState["blancas"] + 1;



                        }
                    }
                    else if (color == "negro")
                    {

                        if (c2.BackColor.Name == "Black")
                        {
                            ViewState["turno"] = 0;
                            c1.BackColor = System.Drawing.Color.Black;
                            guardarfichas(o, 0);
                            ViewState["negras"] = (int)ViewState["negras"] + 1;

                        }
                    }
                }





            }
        }
        protected void a1_Click(object sender, EventArgs e)
        {
            pruebadiego("a1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            pruebadiego("b1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c1_Click(object sender, EventArgs e)
        {
            pruebadiego("c1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d1_Click(object sender, EventArgs e)
        {
            pruebadiego("d1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e1_Click(object sender, EventArgs e)
        {
            pruebadiego("e1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f1_Click(object sender, EventArgs e)
        {
            pruebadiego("f1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g1_Click(object sender, EventArgs e)
        {
            pruebadiego("g1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h1_Click(object sender, EventArgs e)
        {
            pruebadiego("h1", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h1.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h1.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h1", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a2_Click(object sender, EventArgs e)
        {
            pruebadiego("a2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            pruebadiego("b2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c2_Click(object sender, EventArgs e)
        {
            pruebadiego("c2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d2_Click(object sender, EventArgs e)
        {
            pruebadiego("d2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e2_Click(object sender, EventArgs e)
        {
            pruebadiego("e2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f2_Click(object sender, EventArgs e)
        {
            pruebadiego("f2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g2_Click(object sender, EventArgs e)
        {
            pruebadiego("g2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h2_Click(object sender, EventArgs e)
        {
            pruebadiego("h2", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h2.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h2.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h2", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a3_Click(object sender, EventArgs e)
        {
            pruebadiego("a3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            pruebadiego("b3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c3_Click(object sender, EventArgs e)
        {
            pruebadiego("c3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d3_Click(object sender, EventArgs e)
        {
            pruebadiego("d3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e3_Click(object sender, EventArgs e)
        {
            pruebadiego("e3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    e3.BackColor = System.Drawing.Color.White;
                    ViewState["t"] = 1;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    e3.BackColor = System.Drawing.Color.Black;
                    ViewState["t"] = 1;

                }
            }
            pruebadiego2("e3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }

        }

        protected void f3_Click(object sender, EventArgs e)
        {
            pruebadiego("f3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g3_Click(object sender, EventArgs e)
        {
            pruebadiego("g3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h3_Click(object sender, EventArgs e)
        {
            pruebadiego("h3", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h3.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h3.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h3", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a4_Click(object sender, EventArgs e)
        {
            pruebadiego("a4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            pruebadiego("b4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c4_Click(object sender, EventArgs e)
        {
            pruebadiego("c4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d4_Click(object sender, EventArgs e)
        {
            pruebadiego("d4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e4_Click(object sender, EventArgs e)
        {
            pruebadiego("e4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f4_Click(object sender, EventArgs e)
        {
            pruebadiego("f4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g4_Click(object sender, EventArgs e)
        {
            pruebadiego("g4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g4.BackColor = System.Drawing.Color.White;


                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h4_Click(object sender, EventArgs e)
        {
            pruebadiego("h4", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h4.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h4.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h4", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a5_Click(object sender, EventArgs e)
        {
            pruebadiego("a5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            pruebadiego("b5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c5_Click(object sender, EventArgs e)
        {
            pruebadiego("c5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c5.BackColor = System.Drawing.Color.White;



                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c5.BackColor = System.Drawing.Color.Black;



                }

            }

            pruebadiego2("c5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d5_Click(object sender, EventArgs e)
        {
            pruebadiego("d5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e5_Click(object sender, EventArgs e)
        {
            pruebadiego("e5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f5_Click(object sender, EventArgs e)
        {
            pruebadiego("f5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g5_Click(object sender, EventArgs e)
        {
            pruebadiego("g5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h5_Click(object sender, EventArgs e)
        {
            pruebadiego("h5", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h5.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h5.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h5", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a6_Click(object sender, EventArgs e)
        {
            pruebadiego("a6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            pruebadiego("b6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c6_Click(object sender, EventArgs e)
        {
            pruebadiego("c6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d6_Click(object sender, EventArgs e)
        {
            pruebadiego("d6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e6_Click(object sender, EventArgs e)
        {
            pruebadiego("e6", Color2());

            if (contador2 >= 1 && contador3 >= 1)
            {

                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f6_Click(object sender, EventArgs e)
        {
            pruebadiego("f6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f6.BackColor = System.Drawing.Color.Black;

                }

            }
            pruebadiego2("f6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g6_Click(object sender, EventArgs e)
        {
            pruebadiego("g6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h6_Click(object sender, EventArgs e)
        {
            pruebadiego("h6", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h6.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h6.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h6", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a7_Click(object sender, EventArgs e)
        {
            pruebadiego("a7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            pruebadiego("b7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c7_Click(object sender, EventArgs e)
        {
            pruebadiego("c7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d7_Click(object sender, EventArgs e)
        {
            pruebadiego("d7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e7_Click(object sender, EventArgs e)
        {
            pruebadiego("e7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f7_Click(object sender, EventArgs e)
        {
            pruebadiego("f7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g7_Click(object sender, EventArgs e)
        {
            pruebadiego("g7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h7_Click(object sender, EventArgs e)
        {
            pruebadiego("h7", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h7.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h7.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h7", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void a8_Click(object sender, EventArgs e)
        {
            pruebadiego("a8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    a8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    a8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("a8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            pruebadiego("b8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    b8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    b8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("b8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void c8_Click(object sender, EventArgs e)
        {
            pruebadiego("c8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    c8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    c8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("c8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void d8_Click(object sender, EventArgs e)
        {
            pruebadiego("d8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    d8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    d8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("d8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void e8_Click(object sender, EventArgs e)
        {
            pruebadiego("e8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    e8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    e8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("e8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void f8_Click(object sender, EventArgs e)
        {
            pruebadiego("f8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    f8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    f8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("f8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void g8_Click(object sender, EventArgs e)
        {
            pruebadiego("g8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    g8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    g8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("g8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
        }

        protected void h8_Click(object sender, EventArgs e)
        {
            pruebadiego("h8", Color2());
            if (contador2 >= 1 && contador3 >= 1)
            {
                if (Color() == 1)
                {
                    ViewState["bandera"] = 0;
                    ViewState["t"] = 1;
                    h8.BackColor = System.Drawing.Color.White;

                }
                else
                {
                    ViewState["bandera"] = 1;
                    ViewState["t"] = 1;
                    h8.BackColor = System.Drawing.Color.Black;

                }
            }
            pruebadiego2("h8", (int)ViewState["turno"]);
            mov();
            if (WebForm1.num == 2)
            {
                if ((int)ViewState["turno"] != 0)
                {
                    maquinas();
                }
            }
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


        protected void Button1_Click(object sender, EventArgs e)
        {

            guarda();

        }

        public void guarda()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("Tablero");
            doc.AppendChild(raiz);




            for (int i = 1; i <= 8; i++)
            {
                string a = "a" + i.ToString();
                string b = "b" + i.ToString();
                string c = "c" + i.ToString();
                string d = "d" + i.ToString();
                string e = "e" + i.ToString();
                string f = "f" + i.ToString();
                string g = "g" + i.ToString();
                string h = "h" + i.ToString();
                Button c1 = FindControl(a) as Button;
                Button c2 = FindControl(b) as Button;
                Button c3 = FindControl(c) as Button;
                Button c4 = FindControl(d) as Button;
                Button c5 = FindControl(e) as Button;
                Button c6 = FindControl(f) as Button;
                Button c7 = FindControl(g) as Button;
                Button c8 = FindControl(h) as Button;

                if (c1 != null)
                {
                    if (c1.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("A"));
                        ficha.AppendChild(columna);

                    }
                    else if (c1.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("A"));
                        ficha.AppendChild(columna);
                    }

                }
                if (c2 != null)
                {
                    if (c2.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("B"));
                        ficha.AppendChild(columna);
                        ;
                    }
                    else if (c2.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("B"));
                        ficha.AppendChild(columna);
                    }
                }
                if (c3 != null)
                {
                    if (c3.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("C"));
                        ficha.AppendChild(columna);

                    }
                    else if (c3.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("C"));
                        ficha.AppendChild(columna);
                    }


                }
                if (c4 != null)
                {
                    if (c4.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("D"));
                        ficha.AppendChild(columna);

                    }
                    else if (c4.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("D"));
                        ficha.AppendChild(columna);
                    }
                }
                if (c5 != null)
                {
                    if (c5.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("E"));
                        ficha.AppendChild(columna);

                    }
                    else if (c5.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("E"));
                        ficha.AppendChild(columna);
                    }
                }
                if (c6 != null)
                {
                    if (c6.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("F"));
                        ficha.AppendChild(columna);

                    }
                    else if (c6.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("F"));
                        ficha.AppendChild(columna);
                    }
                }
                if (c7 != null)
                {
                    if (c7.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("G"));
                        ficha.AppendChild(columna);

                    }
                    else if (c7.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("G"));
                        ficha.AppendChild(columna);
                    }
                }
                if (c8 != null)
                {
                    if (c8.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("H"));
                        ficha.AppendChild(columna);
                    }
                    else if (c8.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("ficha");
                        raiz.AppendChild(ficha);

                        XmlElement color = doc.CreateElement("color");
                        color.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(color);

                        XmlElement fila = doc.CreateElement("fila");
                        fila.AppendChild(doc.CreateTextNode(i.ToString()));
                        ficha.AppendChild(fila);

                        XmlElement columna = doc.CreateElement("columna");
                        columna.AppendChild(doc.CreateTextNode("H"));
                        ficha.AppendChild(columna);
                    }
                }
            }
            doc.Save("C:\\Users\\DELL\\Desktop\\ConexionSQL\\prueba.xml");
        }

        public void cargar()
        {
            string cf = "";
            string columna = "";
            string fila = "";
            string ficha = "";
            int val = 0;

            using (XmlTextReader xmlReader = new XmlTextReader(@"C:\\Users\\DELL\\Desktop\\ConexionSQL\\" + WebForm1.nombre))
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
            xmlDoc.Load(@"C:\\Users\\DELL\\Desktop\\ConexionSQL\\"+WebForm1.nombre);
            for (int i = 0; i < val; i++)
            {
                foreach (XmlNode xmlNode in xmlDoc.DocumentElement.ChildNodes[i].ChildNodes)
                {
                    if (xmlNode.Name.Equals("color"))
                    {
                        cf = xmlNode.InnerText;
                    }
                    else if (xmlNode.Name.Equals("columna"))
                    {
                        columna = xmlNode.InnerText;
                    }
                    else if (xmlNode.Name.Equals("fila"))
                    {
                        fila = xmlNode.InnerText;
                    }
                }
                string columnaF = columna.ToLower();
                ficha = columnaF + fila;

                Button Nid = FindControl(ficha) as Button;
                if (cf.Equals("Negro"))
                {
                    //a1.BackColor = System.Drawing.Color.White;
                    Nid.BackColor = System.Drawing.Color.Black;
                    guardarfichas(ficha, 0);
                }
                else if (cf.Equals("Blanco"))
                {
                    //a1.BackColor = System.Drawing.Color.White;
                    Nid.BackColor = System.Drawing.Color.White;
                    guardarfichas(ficha, 1);
                }
            }


        }
        public void verificarcargar(string id)
        {
            int diego = 1;
            int es = 1;
            int puto = 1;
            int culero = 1;
            contador2 = 0;

            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getid().Equals(id))
                {


                    diego = prueba.Getx() + 1;
                    es = prueba.Gety() + 1;
                    puto = prueba.Getx() - 1;
                    culero = prueba.Gety() - 1;
                    if (diego <= 9 && es <= 9 && puto >= 0 && culero >= 0)
                    {

                        verificerca(prueba.Getx(), es, prueba.Getcolor());
                        verificerca(diego, es, prueba.Getcolor());
                        verificerca(puto, es, prueba.Getcolor());
                        verificerca(diego, prueba.Gety(), prueba.Getcolor());
                        verificerca(puto, prueba.Gety(), prueba.Getcolor());
                        verificerca(prueba.Getx(), culero, prueba.Getcolor());
                        verificerca(puto, culero, prueba.Getcolor());
                        verificerca(diego, culero, prueba.Getcolor());




                    }





                }
            }
        }
        private void verificerca(int x, int y, string color)
        {


            foreach (Ficha prueba in fichita)
            {
                if (prueba.Getx() == x && prueba.Gety() == y && prueba.Getocupado() == true)
                {
                    if (prueba.Getcolor().Equals("blanco"))
                    {

                        contador2++;

                    }
                    else if (prueba.Getcolor().Equals("negro"))
                    {
                        contador2++;
                    }
                    else
                    {
                        contador2 = 0;

                    }

                }





            }

        }
        public void verdes()
        {
            foreach (Ficha prueba in fichita)
            {
                verificarcargar(prueba.Getid());
                if (contador2 == 0)
                {
                    Button chev = FindControl(prueba.Getid()) as Button;
                    chev.BackColor = System.Drawing.Color.ForestGreen;
                }
            }

        }

        public void maquinas()
        {
            ayuda = 0;
            Random aleatorio = new Random();
            int numero;

            if (maquina.Count != 0)
            {
                numero = aleatorio.Next(0, maquina.Count());
                string id = maquina.ElementAt(numero);

                Button ma = FindControl(id) as Button;
                pruebadiego(id, Color2());
                if (contador2 >= 1 && contador3 >= 1)
                {
                    if (Color() == 1)
                    {
                        ViewState["bandera"] = 0;
                        ViewState["t"] = 1;
                        ma.BackColor = System.Drawing.Color.White;

                    }
                    else
                    {
                        ViewState["bandera"] = 1;
                        ViewState["t"] = 1;
                        ma.BackColor = System.Drawing.Color.Black;

                    }
                    pruebadiego2(id, (int)ViewState["turno"]);
                    mov();
                }
            }
        }
        //public void datos(string usuario)
        //{
        //    string connectionString = @"Data Source=DESKTOP-OFV01SM;Initial Catalog=Datos;Integrated Security=True;";
        //    using (SqlConnection sqlCon = new SqlConnection(connectionString))
        //    {

        //        sqlCon.Open();
        //        if (encontrar(usuario) == true)
        //        {
        //            Response.Write("<script>window.alert('El nombre de usuario ya esta registrado, ingrese uno nuevo')</script>");
        //            sqlCon.Close();
        //        }
        //        else
        //        {
        //            //SqlDataAdapter sqlDa = new SqlDataAdapter("insert into Reportes (nombre, apellido, usuario,modalidad,ganadas,perdidas,empatadas,movimientos) values('" + nombre + "','" + apellido + "','" + usuario + "','" + pass + "','" + nac + "','" + pais + "','" + correo + "')", sqlCon);
        //            DataTable dtb = new DataTable();
        //            //sqlDa.Fill(dtb);
        //            sqlCon.Close();
        //            Response.Write("<script>window.alert('Registro completado :)')</script>");
        //            Response.Redirect("WebForm1.aspx");
        //        }
        //    }
        //}
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
            if (DTbuscar(nombre,G,P,E) == true)
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
        public bool DTbuscar(string nombre,int G,int P, int E)
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
        public void Tiempo()
        {
            int n = 1;
            while (true)
            {
                Jugador1.Text =n.ToString();
                n = n+1;
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.alert('Gano equipo 1')</script>");
            Response.Redirect("WebForm1.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Response.Write("<script>window.alert('Perdio equipo 1')</script>");
            Response.Redirect("WebForm1.aspx");
        }
    }

}


    


    

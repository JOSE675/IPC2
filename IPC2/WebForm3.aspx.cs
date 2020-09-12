using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;

namespace IPC2
{
    public partial class WebForm3 : System.Web.UI.Page
    {

        string p = "a1";
        protected void Page_Load(object sender, EventArgs e)
        {
            d4.BackColor = System.Drawing.Color.White;
            e4.BackColor = System.Drawing.Color.Black;
            d5.BackColor = System.Drawing.Color.Black;
            e5.BackColor = System.Drawing.Color.White;
            
            
            
        }

        protected void a1_Click(object sender, EventArgs e)
        {
            if (Color()==1)
            {
                a1.BackColor = System.Drawing.Color.White;
                Response.Write("<script>window.alert('"+d4.BackColor.Name+ "')</script>");


            } else 
            {
                a1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void c1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                d1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e1.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void f1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                f1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h1_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h1.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h1.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a2.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b2.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void c2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c2.BackColor = System.Drawing.Color.White;
               
            }
            else
            {
                c2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d2.BackColor = System.Drawing.Color.White;
               
            }
            else 
            {
                d2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e2.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void f2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f2.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                f2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g2.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h2_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h2.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                h2.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a3.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b3.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b3.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void c3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c3.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d3_Click(object sender, EventArgs e)
        {
            if (Color()== 1)
            {
                d3.BackColor = System.Drawing.Color.White;
               
            }
            else 
            {
                d3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e3.BackColor = System.Drawing.Color.White;
              
            }
            else 
            {
                e3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void f3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f3.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                f3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g3.BackColor = System.Drawing.Color.White;
               
            }
            else
            {
                g3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h3_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h3.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h3.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a4.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b4.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void c4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c4.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                d4.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void e4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e4.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void f4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                f4.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g4.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h4_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h4.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h4.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void c5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d5.BackColor = System.Drawing.Color.White;
               
            }
            else 
            {
                d5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e5.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void f5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f5.BackColor = System.Drawing.Color.White;
               
            }
            else 
            {
                f5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h5_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h5.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h5.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void c6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d6.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                d6.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void e6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e6.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                e6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void f6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                f6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h6_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h6.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h6.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b7.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void c7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c7.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                c7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                d7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e7.BackColor = System.Drawing.Color.Black;
               
            }
        }

        protected void f7_Click(object sender, EventArgs e)
        {
            if (Color()== 1)
            {
                f7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                f7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                g7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h7_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h7.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h7.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void a8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                a8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                a8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void b8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                b8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                b8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void c8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                c8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                c8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void d8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                d8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                d8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void e8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                e8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                e8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void f8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                f8.BackColor = System.Drawing.Color.White;
               
            }
            else 
            {
                f8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void g8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                g8.BackColor = System.Drawing.Color.White;
                
            }
            else
            {
                g8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        protected void h8_Click(object sender, EventArgs e)
        {
            if (Color() == 1)
            {
                h8.BackColor = System.Drawing.Color.White;
                
            }
            else 
            {
                h8.BackColor = System.Drawing.Color.Black;
                
            }
        }

        public int Color()
        {
            int re = 1;

            if (ViewState["click"] != null) {
                
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

        protected void Button1_Click(object sender, EventArgs e)
        {

            guarda();

        }

        public void guarda()
        {
            XmlDocument doc = new XmlDocument();
            XmlElement raiz = doc.CreateElement("Tablero");
            doc.AppendChild(raiz);
            

            

            for(int i=1; i <= 8; i++)
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

                if (c1!=null)
                {
                    if (c1.BackColor.Name == "White") {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(a));
                        ficha.AppendChild(posicion);

                    }else if (c1.BackColor.Name == "Black"){
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(b));
                        ficha.AppendChild(posicion);
                    }
                    
                }
                if (c2 != null)
                {
                    if (c2.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(b));
                        ficha.AppendChild(posicion);

                    }
                    else if (c2.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(b));
                        ficha.AppendChild(posicion);
                    }
                }
                if (c3 != null)
                {
                    if (c3.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(c));
                        ficha.AppendChild(posicion);

                    }
                    else if (c3.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(c));
                        ficha.AppendChild(posicion);
                    }

                    
                }
                if (c4 != null)
                {
                    if (c4.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(d));
                        ficha.AppendChild(posicion);

                    }
                    else if (c4.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(d));
                        ficha.AppendChild(posicion);
                    }
                }
                if (c5 != null)
                {
                    if (c5.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(e));
                        ficha.AppendChild(posicion);

                    }
                    else if (c5.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(e));
                        ficha.AppendChild(posicion);
                    }
                }
                if (c6 != null)
                {
                    if (c6.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(f));
                        ficha.AppendChild(posicion);

                    }
                    else if (c6.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(f));
                        ficha.AppendChild(posicion);
                    }
                }
                if (c7 != null)
                {
                    if (c7.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(g));
                        ficha.AppendChild(posicion);

                    }
                    else if (c7.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(g));
                        ficha.AppendChild(posicion);
                    }
                }
                if (c8 != null)
                {
                    if (c8.BackColor.Name == "White")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Blanco"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(h));
                        ficha.AppendChild(posicion);

                    }
                    else if (c8.BackColor.Name == "Black")
                    {
                        XmlElement ficha = doc.CreateElement("Ficha");
                        raiz.AppendChild(ficha);

                        XmlElement fcolor = doc.CreateElement("Color");
                        fcolor.AppendChild(doc.CreateTextNode("Negro"));
                        ficha.AppendChild(fcolor);

                        XmlElement posicion = doc.CreateElement("Posicion");
                        posicion.AppendChild(doc.CreateTextNode(h));
                        ficha.AppendChild(posicion);
                    }
                }
            }
            doc.Save("C:\\Users\\DELL\\Desktop\\ConexionSQL\\prueba.xml");
        }
    }
        }
    

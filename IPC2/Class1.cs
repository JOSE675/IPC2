using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IPC2
{
    public class Ficha
    {
        private int x;
        private int y;
        private bool ocupado;
        string id;
        string color;
        public Ficha()
        {


        }

        public Ficha(int x, int y, bool ocupado, string id,string color)
        {
            this.x = x;
            this.y = y;
            this.ocupado = ocupado;
            this.id = id;
            this.color = color;
        }

        public int Getx()
        {
            return x;
        }

        public int Gety()
        {
            return y;
        }

        public bool Getocupado()
        {
            return ocupado;
        }

        public string Getid()
        {
            return id;
        }

        public string Getcolor()
        {
            return color;
        }

        public void Setx(int x)
        {
            this.x = x;
        }

        public void Sety(int y)
        {
            this.y = y;
        }

        public void Setocupado(bool ocupado)
        {
            this.ocupado = ocupado;
        }

        public void Setid(string id)
        {
            this.id = id;
        }

        public void Setcolor(string color)
        {
            this.color = color;
        }


    }


}
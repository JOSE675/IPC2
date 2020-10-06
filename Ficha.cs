using System;

public class Ficha
{
    private int x;
    private int y;
    private bool ocupado;
    string id;
	public Ficha()
	{
        
        
	}

    public Ficha(int x, int y, bool ocupado, string id, string color)
    {
        thix.x = x;
        this.y = y;
        this.ocupado = ocupado;
        this.id = id;

    }

    public Getx()
    {
        return x;
    }

    public Gety()
    {
        return y;
    }

    public Getocupado()
    {
        return ocupado;
    }

    public Getid()
    {
        return id;
    }
    
    public Setx(int x)
    {
        this.x = x;
    }

    public Sety(int y)
    {
        this.y = y;
    }

    public Setocupado(bool ocupado)
    {
        this.ocupado = ocupado;
    }

    public Setid(string id)
    {
        this.id = id;
    }


}

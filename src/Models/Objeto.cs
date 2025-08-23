using System.Collections.Generic;

public class Objeto
{
    public List<Cara> Caras { get; set; }

    public Objeto()
    {
        Caras = new List<Cara>();
    }

    public void AgregarCara(Cara cara)
    {
        Caras.Add(cara);
    }
}
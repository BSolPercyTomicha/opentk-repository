using System.Collections.Generic;

public class Cara
{
    public List<Vertice> Vertices { get; set; }

    public Cara()
    {
        Vertices = new List<Vertice>();
    }

    public void AgregarVertice(Vertice vertice)
    {
        Vertices.Add(vertice);
    }
}
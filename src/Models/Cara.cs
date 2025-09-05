using OpenTK.Mathematics;

public class Cara
{
    public List<Vector3> Vertices { get; set; }
    public Vector4 Color { get; set; }

    public Cara(Vector4 color)
    {
        Vertices = new List<Vector3>();
        Color = color;
    }

    public void AgregarVertice(Vector3 vertice)
    {
        Vertices.Add(vertice);
    }

    public void AgregarVertice(float x, float y, float z)
    {
        Vertices.Add(new Vector3(x, y, z));
    }
}
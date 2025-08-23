using OpenTK.Mathematics;

public class Vertice
{
    public Vector3 Position { get; set; }
    public Vector4 Color { get; set; }

    public Vertice(float x, float y, float z, float r, float g, float b, float a)
    {
        Position = new Vector3(x, y, z);
        Color = new Vector4(r, g, b, a);
    }
}
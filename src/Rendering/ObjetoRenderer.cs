using OpenTK.Graphics.OpenGL;
using System.Linq;

public class ObjetoRenderer
{
    private int _vao, _vbo, _shader;
    private Objeto _objeto;
    private float[] _vertexData;

    public ObjetoRenderer(Objeto objeto)
    {
        _objeto = objeto;
        ConvertirObjetoADatosVertice();
    }

    private void ConvertirObjetoADatosVertice()
    {
        var vertexList = new List<float>();

        foreach (var cara in _objeto.Caras)
        {
            foreach (var vertice in cara.Vertices)
            {
                vertexList.Add(vertice.Position.X);
                vertexList.Add(vertice.Position.Y);
                vertexList.Add(vertice.Position.Z);

                vertexList.Add(vertice.Color.X);
                vertexList.Add(vertice.Color.Y);
                vertexList.Add(vertice.Color.Z);
                vertexList.Add(vertice.Color.W);
            }
        }

        _vertexData = vertexList.ToArray();
    }

    public void Load()
    {
        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);

        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, _vertexData.Length * sizeof(float), _vertexData, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 7 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        GL.VertexAttribPointer(1, 4, VertexAttribPointerType.Float, false, 7 * sizeof(float), 3 * sizeof(float));
        GL.EnableVertexAttribArray(1);

        _shader = ShaderCompiler.CompileShaderProgram(
            @"#version 330 core
                layout(location = 0) in vec3 aPos;
                layout(location = 1) in vec4 aColor;
                
                out vec4 ourColor;
                
                void main()
                {
                    gl_Position = vec4(aPos, 1.0);
                    ourColor = aColor;
                }",

            @"#version 330 core
                in vec4 ourColor;
                out vec4 FragColor;
                
                void main()
                {
                    FragColor = ourColor;
                }"
        );
    }

    public void Render()
    {
        GL.UseProgram(_shader);
        GL.BindVertexArray(_vao);

        int vertexOffset = 0;
        foreach (var cara in _objeto.Caras)
        {
            GL.DrawArrays(PrimitiveType.Triangles, vertexOffset, cara.Vertices.Count);
            vertexOffset += cara.Vertices.Count;
        }
    }

    public void Unload()
    {
        GL.DeleteVertexArray(_vao);
        GL.DeleteBuffer(_vbo);
        GL.DeleteProgram(_shader);
    }
}
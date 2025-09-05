using OpenTK.Graphics.OpenGL;
using OpenTK.Mathematics;

public class ObjetoRenderer
{
    private int _vao, _vbo, _shader;
    private Objeto _objeto;
    private float[] _vertexData;

    // Matrices para la transformación 3D
    private Matrix4 _projection;
    private Matrix4 _view;
    private Matrix4 _model;

    public ObjetoRenderer(Objeto objeto)
    {
        _objeto = objeto;
        _projection = Matrix4.Identity;
        _view = Matrix4.Identity;
        _model = Matrix4.Identity;
        ConvertirObjetoADatosVertice();
    }

    private void ConvertirObjetoADatosVertice()
    {
        var vertexList = new List<float>();

        foreach (var parte in _objeto.Partes)
        {
            foreach (var cara in parte.Caras)
            {
                foreach (var vertice in cara.Vertices)
                {
                    // Posición del vértice
                    vertexList.Add(vertice.X);
                    vertexList.Add(vertice.Y);
                    vertexList.Add(vertice.Z);

                    // Color del vértice (usando el color de la cara)
                    vertexList.Add(cara.Color.X);
                    vertexList.Add(cara.Color.Y);
                    vertexList.Add(cara.Color.Z);
                    vertexList.Add(cara.Color.W);
                }
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
                
                uniform mat4 projection;
                uniform mat4 view;
                uniform mat4 model;
                
                void main()
                {
                    gl_Position = projection * view * model * vec4(aPos, 1.0);
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

    // Método para establecer las matrices
    public void SetMatrices(Matrix4 projection, Matrix4 view, Matrix4 model)
    {
        _projection = projection;
        _view = view;
        _model = model;
    }

    public void Render()
    {
        GL.UseProgram(_shader);

        // Pasar las matrices al shader
        int projectionLocation = GL.GetUniformLocation(_shader, "projection");
        int viewLocation = GL.GetUniformLocation(_shader, "view");
        int modelLocation = GL.GetUniformLocation(_shader, "model");

        GL.UniformMatrix4(projectionLocation, false, ref _projection);
        GL.UniformMatrix4(viewLocation, false, ref _view);
        GL.UniformMatrix4(modelLocation, false, ref _model);

        GL.BindVertexArray(_vao);

        int vertexOffset = 0;
        foreach (var parte in _objeto.Partes)
        {
            foreach (var cara in parte.Caras)
            {
                GL.DrawArrays(PrimitiveType.Triangles, vertexOffset, cara.Vertices.Count);
                vertexOffset += cara.Vertices.Count;
            }
        }

        // Limpiar el estado
        GL.BindVertexArray(0);
        GL.UseProgram(0);
    }

    public void Unload()
    {
        GL.DeleteVertexArray(_vao);
        GL.DeleteBuffer(_vbo);
        GL.DeleteProgram(_shader);
    }
}
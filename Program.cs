using OpenTK.Graphics.OpenGL;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

class Game : GameWindow
{
    private int _vao, _vbo, _shader;

    public Game() : base(GameWindowSettings.Default,
        new NativeWindowSettings() { ClientSize = (500, 500), Title = "Hola Mundo" })
    { }

    protected override void OnLoad()
    {
        base.OnLoad();
        GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);

        float[] vertices = {
            -0.5f, -0.5f, 0.0f,
             0.5f, -0.5f, 0.0f,
             0.0f,  0.5f, 0.0f,
        };

        _vao = GL.GenVertexArray();
        GL.BindVertexArray(_vao);

        _vbo = GL.GenBuffer();
        GL.BindBuffer(BufferTarget.ArrayBuffer, _vbo);
        GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);

        GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
        GL.EnableVertexAttribArray(0);

        _shader = GL.CreateProgram();
        int vertShader = GL.CreateShader(ShaderType.VertexShader);
        int fragShader = GL.CreateShader(ShaderType.FragmentShader);

        GL.ShaderSource(vertShader, @"#version 330
            layout(location=0) in vec3 pos;
            void main() { gl_Position = vec4(pos, 1.0); }");
        GL.CompileShader(vertShader);

        GL.ShaderSource(fragShader, @"#version 330
            out vec4 color;
            void main() { color = vec4(1.0, 0.5, 0.2, 1.0); }");
        GL.CompileShader(fragShader);

        GL.AttachShader(_shader, vertShader);
        GL.AttachShader(_shader, fragShader);
        GL.LinkProgram(_shader);

        GL.DeleteShader(vertShader);
        GL.DeleteShader(fragShader);
    }

    protected override void OnRenderFrame(FrameEventArgs e)
    {
        base.OnRenderFrame(e);
        GL.Clear(ClearBufferMask.ColorBufferBit);

        GL.UseProgram(_shader);
        GL.BindVertexArray(_vao);
        GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

        SwapBuffers();
    }

    protected override void OnResize(ResizeEventArgs e)
    {
        base.OnResize(e);
        GL.Viewport(0, 0, e.Width, e.Height);
    }

    static void Main() => new Game().Run();
}
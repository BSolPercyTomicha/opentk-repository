using OpenTK.Graphics.OpenGL;

public static class ShaderCompiler
{
    public static int CompileShaderProgram(string vertexShaderSource, string fragmentShaderSource)
    {
        int program = GL.CreateProgram();
        int vertShader = CompileShader(ShaderType.VertexShader, vertexShaderSource);
        int fragShader = CompileShader(ShaderType.FragmentShader, fragmentShaderSource);

        GL.AttachShader(program, vertShader);
        GL.AttachShader(program, fragShader);
        GL.LinkProgram(program);

        GL.DeleteShader(vertShader);
        GL.DeleteShader(fragShader);

        return program;
    }

    private static int CompileShader(ShaderType type, string source)
    {
        int shader = GL.CreateShader(type);
        GL.ShaderSource(shader, source);
        GL.CompileShader(shader);

        GL.GetShader(shader, ShaderParameter.CompileStatus, out int success);
        if (success == 0)
        {
            string infoLog = GL.GetShaderInfoLog(shader);
            throw new Exception($"Error al compilar shader {type}: {infoLog}");
        }

        return shader;
    }
}
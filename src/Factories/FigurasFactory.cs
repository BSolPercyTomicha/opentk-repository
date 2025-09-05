using OpenTK.Mathematics;

public static class FigurasFactory
{
    public static Objeto CrearMonitor()
    {
        var objeto = new Objeto();
        var parte = new Parte();
        float ancho = 1.0f;
        float alto = 0.8f;
        float profundidad = 0.1f;
        float x = 0.0f;
        float y = 0.5f;
        float z = 0.0f;

        // Cara frontal (pantalla)
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            Color.White
        );
        parte.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.Black
        );
        parte.AgregarCara(trasera);

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            Color.Black
        );
        parte.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            Color.Black
        );
        parte.AgregarCara(inferior);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.Black
        );
        parte.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.Black
        );
        parte.AgregarCara(derecha);

        // Base del monitor
        CrearBaseMonitor(objeto, x, y - alto / 2, z, Color.Black);

        objeto.AgregarParte(parte);
        return objeto;
    }

    private static void CrearBaseMonitor(Objeto objeto, float x, float y, float z, Vector4 color)
    {
        float baseAncho = 0.4f;
        float baseAlto = 0.3f;
        float baseProfundidad = 0.4f;
        var parte = new Parte();

        // Base frontal
        var baseFrente = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseFrente);

        // Base trasera
        var baseTrasera = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseTrasera);

        // Base superior
        var baseSuperior = CrearCaraCubo(
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseSuperior);

        // Base inferior
        var baseInferior = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseInferior);

        // Base izquierda
        var baseIzquierda = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseIzquierda);

        // Base derecha
        var baseDerecha = CrearCaraCubo(
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        parte.AgregarCara(baseDerecha);

        objeto.AgregarParte(parte);
    }

    public static Objeto CrearCPU()
    {
        var objeto = new Objeto();
        var parte = new Parte();
        float ancho = 0.5f;
        float alto = 0.7f;
        float profundidad = 0.4f;
        float x = 0.8f;
        float y = 0.0f;
        float z = 0.0f;

        // Cara frontal
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(trasera);

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(inferior);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            Color.LightGray
        );
        parte.AgregarCara(derecha);

        // Botón de encendido (frontal)
        var boton = CrearCaraCubo(
            x - 0.05f, y + alto / 2 - 0.2f, z + profundidad / 2 + 0.01f,
            x + 0.05f, y + alto / 2 - 0.2f, z + profundidad / 2 + 0.01f,
            x + 0.05f, y + alto / 2 - 0.1f, z + profundidad / 2 + 0.01f,
            x - 0.05f, y + alto / 2 - 0.1f, z + profundidad / 2 + 0.01f,
            Color.DarkGray
        );
        parte.AgregarCara(boton);
        objeto.AgregarParte(parte);

        return objeto;
    }

    public static Objeto CrearTeclado()
    {
        var objeto = new Objeto();
        var parte = new Parte();
        float ancho = 1.2f;
        float alto = 0.1f;
        float profundidad = 0.3f;
        float x = 0.0f;
        float y = -0.8f;
        float z = 0.0f;

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y, z - profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x - ancho / 2, y - alto, z + profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(inferior);

        // Cara frontal
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            x - ancho / 2, y, z - profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(trasera);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x - ancho / 2, y - alto, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z - profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            Color.DarkGray
        );
        parte.AgregarCara(derecha);

        CrearTeclas(objeto, (x - ancho / 2) + 0.02f, y, (z - profundidad / 2) + 0.02f, Color.Black);

        objeto.AgregarParte(parte);

        return objeto;
    }

    private static void CrearTeclas(Objeto objeto, float startX, float y, float startZ, Vector4 color)
    {
        float teclaSize = 0.06f;
        float spacing = 0.1f;

        for (int row = 0; row < 3; row++)
        {
            var teclas = new Parte();
            for (int col = 0; col < 12; col++)
            {
                float xPos = startX + col * spacing;
                float zPos = startZ + row * spacing;

                var tecla = CrearCaraCubo(
                    xPos, y, zPos,
                    xPos + teclaSize, y, zPos,
                    xPos + teclaSize, y, zPos + teclaSize,
                    xPos, y, zPos + teclaSize,
                    color
                );
                teclas.AgregarCara(tecla);
            }
            objeto.AgregarParte(teclas);
        }
    }

    private static Cara CrearCaraCubo(float x1, float y1, float z1,
                                     float x2, float y2, float z2,
                                     float x3, float y3, float z3,
                                     float x4, float y4, float z4,
                                     Vector4 color)
    {
        var cara = new Cara(color);

        cara.AgregarVertice(new Vector3(x1, y1, z1));
        cara.AgregarVertice(new Vector3(x2, y2, z2));
        cara.AgregarVertice(new Vector3(x3, y3, z3));

        cara.AgregarVertice(new Vector3(x1, y1, z1));
        cara.AgregarVertice(new Vector3(x3, y3, z3));
        cara.AgregarVertice(new Vector3(x4, y4, z4));

        return cara;
    }
}
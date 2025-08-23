using OpenTK.Mathematics;

public static class FigurasFactory
{
    public static Objeto CrearMonitor()
    {
        var objeto = new Objeto();
        float ancho = 1.0f;
        float alto = 0.8f;
        float profundidad = 0.1f;
        float x = 0.0f;
        float y = 0.5f;
        float z = 0.0f;

        // Color negro para el monitor
        Vector4 colorNegro = new Vector4(0.1f, 0.1f, 0.1f, 1.0f);
        Vector4 colorPantalla = new Vector4(0.8f, 0.8f, 0.8f, 1.0f);

        // Cara frontal (pantalla)
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            colorPantalla
        );
        objeto.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            colorNegro
        );
        objeto.AgregarCara(trasera);

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            colorNegro
        );
        objeto.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            colorNegro
        );
        objeto.AgregarCara(inferior);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            colorNegro
        );
        objeto.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            colorNegro
        );
        objeto.AgregarCara(derecha);

        // Base del monitor
        CrearBaseMonitor(objeto, x, y - alto / 2, z, colorNegro);

        return objeto;
    }

    private static void CrearBaseMonitor(Objeto objeto, float x, float y, float z, Vector4 color)
    {
        float baseAncho = 0.4f;
        float baseAlto = 0.3f;
        float baseProfundidad = 0.4f;

        // Base frontal
        var baseFrente = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseFrente);

        // Base trasera
        var baseTrasera = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseTrasera);

        // Base superior
        var baseSuperior = CrearCaraCubo(
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseSuperior);

        // Base inferior
        var baseInferior = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseInferior);

        // Base izquierda
        var baseIzquierda = CrearCaraCubo(
            x - baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x - baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z + baseProfundidad / 2,
            x - baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseIzquierda);

        // Base derecha
        var baseDerecha = CrearCaraCubo(
            x + baseAncho / 2, y - baseAlto, z - baseProfundidad / 2,
            x + baseAncho / 2, y - baseAlto, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z + baseProfundidad / 2,
            x + baseAncho / 2, y, z - baseProfundidad / 2,
            color
        );
        objeto.AgregarCara(baseDerecha);
    }

    public static Objeto CrearCPU()
    {
        var objeto = new Objeto();
        float ancho = 0.5f;
        float alto = 0.7f;
        float profundidad = 0.4f;
        float x = 0.8f;
        float y = 0.0f;
        float z = 0.0f;

        // Color gris claro para el CPU
        Vector4 colorGrisClaro = new Vector4(0.7f, 0.7f, 0.7f, 1.0f);
        Vector4 colorBotones = new Vector4(0.3f, 0.3f, 0.3f, 1.0f);

        // Cara frontal
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(trasera);

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(inferior);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto / 2, z - profundidad / 2,
            x - ancho / 2, y - alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z + profundidad / 2,
            x - ancho / 2, y + alto / 2, z - profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto / 2, z - profundidad / 2,
            x + ancho / 2, y - alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z + profundidad / 2,
            x + ancho / 2, y + alto / 2, z - profundidad / 2,
            colorGrisClaro
        );
        objeto.AgregarCara(derecha);

        // Botón de encendido (frontal)
        var boton = CrearCaraCubo(
            x - 0.05f, y + alto / 2 - 0.2f, z + profundidad / 2 + 0.01f,
            x + 0.05f, y + alto / 2 - 0.2f, z + profundidad / 2 + 0.01f,
            x + 0.05f, y + alto / 2 - 0.1f, z + profundidad / 2 + 0.01f,
            x - 0.05f, y + alto / 2 - 0.1f, z + profundidad / 2 + 0.01f,
            colorBotones
        );
        objeto.AgregarCara(boton);

        // Ranuras de ventilación (laterales)
        for (int i = 0; i < 3; i++)
        {
            float yPos = y - alto / 2 + 0.3f + i * 0.3f;

            var ranura = CrearCaraCubo(
                x + ancho / 2 + 0.01f, yPos - 0.1f, z - 0.1f,
                x + ancho / 2 + 0.01f, yPos - 0.1f, z + 0.1f,
                x + ancho / 2 + 0.01f, yPos + 0.1f, z + 0.1f,
                x + ancho / 2 + 0.01f, yPos + 0.1f, z - 0.1f,
                colorBotones
            );
            objeto.AgregarCara(ranura);
        }

        return objeto;
    }

    public static Objeto CrearTeclado()
    {
        var objeto = new Objeto();
        float ancho = 1.2f;
        float alto = 0.1f;
        float profundidad = 0.3f;
        float x = 0.0f;
        float y = -0.8f;
        float z = 0.0f;

        // Color gris oscuro para el teclado
        Vector4 colorGrisOscuro = new Vector4(0.3f, 0.3f, 0.3f, 1.0f);
        Vector4 colorTeclas = new Vector4(0.1f, 0.1f, 0.1f, 1.0f);

        // Cara superior
        var superior = CrearCaraCubo(
            x - ancho / 2, y, z - profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(superior);

        // Cara inferior
        var inferior = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x - ancho / 2, y - alto, z + profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(inferior);

        // Cara frontal
        var frente = CrearCaraCubo(
            x - ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(frente);

        // Cara trasera
        var trasera = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            x - ancho / 2, y, z - profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(trasera);

        // Cara izquierda
        var izquierda = CrearCaraCubo(
            x - ancho / 2, y - alto, z - profundidad / 2,
            x - ancho / 2, y - alto, z + profundidad / 2,
            x - ancho / 2, y, z + profundidad / 2,
            x - ancho / 2, y, z - profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(izquierda);

        // Cara derecha
        var derecha = CrearCaraCubo(
            x + ancho / 2, y - alto, z - profundidad / 2,
            x + ancho / 2, y - alto, z + profundidad / 2,
            x + ancho / 2, y, z + profundidad / 2,
            x + ancho / 2, y, z - profundidad / 2,
            colorGrisOscuro
        );
        objeto.AgregarCara(derecha);

        // Teclas (en la superficie superior)
        CrearTeclas(objeto, x - ancho / 2 + 0.1f, y + 0.01f, z - profundidad / 2 + 0.1f, colorTeclas);

        return objeto;
    }

    private static void CrearTeclas(Objeto objeto, float startX, float y, float startZ, Vector4 color)
    {
        float teclaSize = 0.08f;
        float spacing = 0.1f;

        for (int row = 0; row < 4; row++)
        {
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
                objeto.AgregarCara(tecla);
            }
        }

        // Barra espaciadora (más grande)
        var espaciadora = CrearCaraCubo(
            startX + 2f, y, startZ + 3.5f * spacing,
            startX + 8f, y, startZ + 3.5f * spacing,
            startX + 8f, y, startZ + 4.5f * spacing,
            startX + 2f, y, startZ + 4.5f * spacing,
            color
        );
        objeto.AgregarCara(espaciadora);
    }

    private static Cara CrearCaraCubo(float x1, float y1, float z1,
                                     float x2, float y2, float z2,
                                     float x3, float y3, float z3,
                                     float x4, float y4, float z4,
                                     Vector4 color)
    {
        var cara = new Cara();

        // Primer triángulo
        cara.AgregarVertice(new Vertice(x1, y1, z1, color.X, color.Y, color.Z, color.W));
        cara.AgregarVertice(new Vertice(x2, y2, z2, color.X, color.Y, color.Z, color.W));
        cara.AgregarVertice(new Vertice(x3, y3, z3, color.X, color.Y, color.Z, color.W));

        // Segundo triángulo
        cara.AgregarVertice(new Vertice(x1, y1, z1, color.X, color.Y, color.Z, color.W));
        cara.AgregarVertice(new Vertice(x3, y3, z3, color.X, color.Y, color.Z, color.W));
        cara.AgregarVertice(new Vertice(x4, y4, z4, color.X, color.Y, color.Z, color.W));

        return cara;
    }
}
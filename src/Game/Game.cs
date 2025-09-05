using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using OpenTK.Mathematics;
using OpenTK.Windowing.GraphicsLibraryFramework;

namespace OpenTKTriangle.src.Game
{
    public class Game : GameWindow
    {
        private ObjetoRenderer _monitorRenderer;
        private ObjetoRenderer _cpuRenderer;
        private ObjetoRenderer _tecladoRenderer;

        // Variables para la cámara 3D
        private Matrix4 _projection;
        private Matrix4 _view;
        private float _cameraDistance = 5.0f;
        private float _cameraYaw = 0.0f;
        private float _cameraPitch = 0.0f;
        private float _rotationSpeed = 1.5f;

        public Game() : base(GameWindowSettings.Default,
            new NativeWindowSettings()
            {
                ClientSize = (800, 800),
                Title = "Computadora 3D - Vista 3D con Controles"
            })
        {
            var monitor = FigurasFactory.CrearMonitor();
            var cpu = FigurasFactory.CrearCPU();
            var teclado = FigurasFactory.CrearTeclado();

            _monitorRenderer = new ObjetoRenderer(monitor);
            _cpuRenderer = new ObjetoRenderer(cpu);
            _tecladoRenderer = new ObjetoRenderer(teclado);
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            GL.ClearColor(0.0f, 0.3f, 0.0f, 1.0f);

            // Configurar proyección en perspectiva 3D
            float aspectRatio = (float)Size.X / (float)Size.Y;
            _projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,  // 45 grados
                aspectRatio,
                0.1f,                // Plano cercano
                100.0f               // Plano lejano
            );

            // Configurar vista inicial de la cámara
            UpdateCameraView();

            // Habilitar depth test para 3D
            GL.Enable(EnableCap.DepthTest);

            _monitorRenderer.Load();
            _cpuRenderer.Load();
            _tecladoRenderer.Load();

            // Pasar las matrices a los renderers (necesitarás agregar este método)
            SetRendererMatrices();
        }

        private void UpdateCameraView()
        {
            // Calcular posición de la cámara (órbita alrededor del origen)
            Vector3 cameraPosition = new Vector3(
                _cameraDistance * (float)Math.Sin(_cameraYaw) * (float)Math.Cos(_cameraPitch),
                _cameraDistance * (float)Math.Sin(_cameraPitch),
                _cameraDistance * (float)Math.Cos(_cameraYaw) * (float)Math.Cos(_cameraPitch)
            );

            _view = Matrix4.LookAt(cameraPosition, Vector3.Zero, Vector3.UnitY);
        }

        private void SetRendererMatrices()
        {
            // Método para pasar las matrices a todos los renderers
            // Necesitarás implementar SetMatrices en ObjetoRenderer
            Matrix4 model = Matrix4.Identity;

            _monitorRenderer?.SetMatrices(_projection, _view, model);
            _cpuRenderer?.SetMatrices(_projection, _view, model);
            _tecladoRenderer?.SetMatrices(_projection, _view, model);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            // Controles de cámara con teclas direccionales
            float deltaTime = (float)e.Time;

            if (KeyboardState.IsKeyDown(Keys.Left))
            {
                _cameraYaw -= _rotationSpeed * deltaTime;
            }

            if (KeyboardState.IsKeyDown(Keys.Right))
            {
                _cameraYaw += _rotationSpeed * deltaTime;
            }

            if (KeyboardState.IsKeyDown(Keys.Up))
            {
                _cameraPitch += _rotationSpeed * deltaTime;
                // Limitar el ángulo vertical para evitar volteos
                _cameraPitch = MathHelper.Clamp(_cameraPitch, -MathHelper.PiOver2 + 0.1f, MathHelper.PiOver2 - 0.1f);
            }

            if (KeyboardState.IsKeyDown(Keys.Down))
            {
                _cameraPitch -= _rotationSpeed * deltaTime;
                // Limitar el ángulo vertical para evitar volteos
                _cameraPitch = MathHelper.Clamp(_cameraPitch, -MathHelper.PiOver2 + 0.1f, MathHelper.PiOver2 - 0.1f);
            }

            // Zoom con teclas + y -
            if (KeyboardState.IsKeyDown(Keys.W))
            {
                _cameraDistance -= 2.0f * deltaTime;
                _cameraDistance = MathHelper.Clamp(_cameraDistance, 1.0f, 20.0f);
            }

            if (KeyboardState.IsKeyDown(Keys.S))
            {
                _cameraDistance += 2.0f * deltaTime;
                _cameraDistance = MathHelper.Clamp(_cameraDistance, 1.0f, 20.0f);
            }

            // Resetear cámara con tecla R
            if (KeyboardState.IsKeyDown(Keys.R))
            {
                _cameraDistance = 5.0f;
                _cameraYaw = 0.0f;
                _cameraPitch = 0.0f;
            }

            // Salir con ESC
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }

            // Actualizar la vista de la cámara
            UpdateCameraView();
            SetRendererMatrices();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            // Limpiar buffers de color y profundidad
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            _monitorRenderer.Render();
            _cpuRenderer.Render();
            _tecladoRenderer.Render();

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);

            // Actualizar proyección cuando cambia el tamaño de la ventana
            float aspectRatio = (float)e.Width / (float)e.Height;
            _projection = Matrix4.CreatePerspectiveFieldOfView(
                MathHelper.PiOver4,
                aspectRatio,
                0.1f,
                100.0f
            );

            SetRendererMatrices();
        }
    }
}
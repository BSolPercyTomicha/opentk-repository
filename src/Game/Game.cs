using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;

namespace OpenTKTriangle.src.Game
{
    public class Game : GameWindow
    {
        private ObjetoRenderer _monitorRenderer;
        private ObjetoRenderer _cpuRenderer;
        private ObjetoRenderer _tecladoRenderer;

        public Game() : base(GameWindowSettings.Default,
            new NativeWindowSettings()
            {
                ClientSize = (800, 800),
                Title = "Computadora 3D - Vista 2D"
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

            _monitorRenderer.Load();
            _cpuRenderer.Load();
            _tecladoRenderer.Load();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _monitorRenderer.Render();
            _cpuRenderer.Render();
            _tecladoRenderer.Render();

            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, e.Width, e.Height);
        }
    }
}
using OpenTK;
using OpenTK.Graphics.ES11;
using System;
using System.Drawing;

namespace The_adventure_of_quantum
{
    class MainWindow : GameWindow
    {
        static void Main()
        {
            using (MainWindow window = new MainWindow())
            {
                window.Run(30.0);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            Title = "The adventure of Quantum";
            GL.ClearColor(0,0,0,0);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);

            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref modelview);

            SwapBuffers();
        }
        protected override void OnResize(EventArgs e)
        {

            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);

            GL.MatrixMode(MatrixMode.Projection);

            GL.LoadMatrix(ref projection);
        }
    }

    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;

namespace RPG
{
    abstract class Game
    {
        protected RenderWindow window;
        protected Color clearColor;

        public Game(uint width, uint height, string title, Color clearColor)
        {
            this.window = new RenderWindow(new VideoMode(width, height), title, Styles.Close);
            this.clearColor = clearColor;

            // Set up events
            window.Closed += OnClosed;
        }

        public void Run()
        {
            LoadContent();
            Initialize();

            while(window.IsOpen)
            {
                window.DispatchEvents();
                Tick();

                window.Clear(clearColor);
                Render();
                window.Display();
            }
        }

        protected abstract void LoadContent();
        protected abstract void Initialize();

        protected abstract void Tick();
        protected abstract void Render();

        private void OnClosed(object sender, EventArgs e)
        {
            window.Close();
        }
    }
}

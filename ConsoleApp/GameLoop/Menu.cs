using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp
{
    /// <summary>
    /// Main menu class.
    /// </summary>
    public class Menu
    {
        // Enter the game.
        private GameLoop gameLoop;

        /// <summary>
        /// Main menu.
        /// </summary>
        public void MainMenu()
        {
            // Enter the game.
            gameLoop.Game();
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Menu()
        {
            gameLoop = new GameLoop();
        }
    }
}

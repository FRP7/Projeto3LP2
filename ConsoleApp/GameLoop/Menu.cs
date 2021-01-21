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
        private SetupGame setupGame;

        /// <summary>
        /// Main menu.
        /// </summary>
        public void MainMenu()
        {
            // Enter the game.
            setupGame.SetGame();
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Menu()
        {
            setupGame = new SetupGame();
        }
    }
}

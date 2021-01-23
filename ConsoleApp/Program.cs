using System;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Begin the game.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Call the main menu.
        /// </summary>
        private static void Main()
        {
            Menu menu = new Menu();
            menu.MainMenu();
        }
    }
}

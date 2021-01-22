using System;
using Common;

namespace ConsoleApp
{
    /// <summary>
    /// Class where the logic of the game is updated.
    /// </summary>
    public class Update
    {
        public delegate void PlayGameLoop();

        public readonly PlayGameLoop playGameLoop;

        /// <summary>
        /// Update the logic of the game.
        /// </summary>
        public void UpdateGame()
        {
            //Console.WriteLine("Game updated");
            playGameLoop.Invoke();
        }

        /// <summary>
        /// Initialize variables.
        /// </summary>
        public Update(params PlayGameLoop[] play)
        {
            foreach(PlayGameLoop item in play)
            {
                playGameLoop += item;
            }
        }
    }
}

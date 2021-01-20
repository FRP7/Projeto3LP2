using System;

namespace ConsoleApp
{
    /// <summary>
    /// GameObject abstract class.
    /// </summary>
    public abstract class GameObject
    {
        /// <summary>
        /// First frame of the game.
        /// </summary>
        public abstract void Start();

        /// <summary>
        /// Update the gameobject every frame of the game.
        /// </summary>
        public abstract void Update();

        /// <summary>
        /// Render the gameobject.
        /// </summary>
        public abstract void Render();
    }
}

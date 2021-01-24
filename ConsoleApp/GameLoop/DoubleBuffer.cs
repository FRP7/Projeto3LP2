using System;

namespace ConsoleApp
{
    /// <summary>
    /// Class that controls the render's update.
    /// </summary>
    /// <typeparam name="T"> Type of render.</typeparam>
    public class DoubleBuffer<T>
    {
        // Current render.
        private T[,] current;

        // Next image to be rendered.
        private T[,] next;

        /// <summary>
        /// Gets a value indicating the width of the current render.
        /// </summary>
        public int XDim => current.GetLength(0);

        /// <summary>
        /// Gets a value indicating the height of the current render.
        /// </summary>
        public int YDim => current.GetLength(1);

        /// <summary>
        /// Indexer.
        /// </summary>
        /// <param name="x"> Render width.</param>
        /// <param name="y">Render height.</param>
        /// <returns> Returns DoubleBuffer.</returns>
        public T this[int x, int y]
        {
            get => current[x, y];
            set => next[x, y] = value;
        }

        /// <summary>
        /// Clear the next render array.
        /// </summary>
        public void Clear()
        {
            Array.Clear(next, 0, XDim * YDim);
        }

        /// <summary>
        /// Initialize the variables.
        /// </summary>
        /// <param name="x"> Render's width.</param>
        /// <param name="y"> Render's height.</param>
        public DoubleBuffer(int x, int y)
        {
            current = new T[x, y];
            next = new T[x, y];
        }

        /// <summary>
        /// Swap the current render with the next render.
        /// </summary>
        public void Swap()
        {
            T[,] aux = current;
            current = next;
            next = aux;
            Clear();
        }
    }
}

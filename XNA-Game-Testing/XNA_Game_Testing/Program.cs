using System;

namespace XNA_Game_Testing
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (Menu game = new Menu())
            {
                game.Run();
            }
        }
    }
#endif
}


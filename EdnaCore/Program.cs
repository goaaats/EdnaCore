using System;

namespace EdnaCore
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new EdnaGame())
                game.Run();
        }
    }
}

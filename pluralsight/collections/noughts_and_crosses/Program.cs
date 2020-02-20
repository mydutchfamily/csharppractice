using System;

namespace noughts_and_crosses
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.PlayGame();
            System.Console.WriteLine("Game Over");
        }
    }
}

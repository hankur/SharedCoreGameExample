using System;
using Core;

namespace ConsoleGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to console game!");

            var game = new GameEngine(10);
            
            var player1 = new Player("Peeter");
            game.AddPlayer(player1);
            
            var player2 = new Player("Jüri");
            game.AddPlayer(player2);

            PlayGame(game);
        }

        private static void PlayGame(GameEngine game)
        {
            while (true)
            {
                Console.Clear();
                
                foreach (var pl in game.state.Players)
                    Console.WriteLine($"{pl.Name} points: {pl.Points}");

                var player = game.WhoseTurn();
                
                Console.Write($"Take your guess between 1 and 10, {player.Name}: ");
                int.TryParse(Console.ReadLine(), out var guess);
                Console.WriteLine();
                
                var goalHit = game.PlayerGuess(guess);
                if (goalHit)
                    Console.WriteLine($"Good job, {player.Name}! You hit the goal: {guess}!");
                else
                    Console.WriteLine($"Sorry, {player.Name}! You missed!");
                
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
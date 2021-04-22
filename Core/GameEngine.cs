using System;
using System.Linq;

namespace Core
{
    public class GameEngine
    {
        public GameState state { get; set; } = new();

        private int MaxGoal;
        private Random random = new();
        
        public GameEngine(int maxGoal)
        {
            MaxGoal = maxGoal;
            state.Goal = GetNewGoal();
        }

        public void AddPlayer(Player player)
        {
            state.Players.Add(player);
        }

        public Player WhoseTurn()
        {
            return state.NextPlayer ?? state.Players[0];
        }

        // Return if goal was hit or not 
        public bool PlayerGuess(int guess)
        {
            var player = WhoseTurn();

            // Bingo gives points
            if (state.Goal == guess)
            {
                player.Points += 10;
                state.Goal = GetNewGoal();
                state.NextPlayer = GetNextOf(player);
                return true;
            }

            // Missing costs points
            if (state.Goal > guess) {
                player.Points -= 5;
                state.NextPlayer = GetNextOf(player);
                return false;
            }
            if (state.Goal < guess)
            {
                player.Points -= 1;
                state.NextPlayer = GetNextOf(player);
                return false;
            }

            return false;
        }

        private int GetNewGoal()
        {
            return random.Next(MaxGoal) + 1;
        }

        private Player GetNextOf(Player player)
        {
            return state.Players.SkipWhile(x => x != player).Skip(1)
                .DefaultIfEmpty(state.Players[0]).FirstOrDefault();
        }
    }
}